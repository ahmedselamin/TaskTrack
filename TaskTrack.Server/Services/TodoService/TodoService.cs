namespace TaskTrack.Server.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly DataContext _context;

        public TodoService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Todo>>> FetchTodos(int userId)
        {
            var response = new ServiceResponse<List<Todo>>();

            try
            {
                var todos = await _context.Todos
                    .Where(t => t.UserId == userId)
                    .OrderByDescending(t => t.Timestamp)
                    .ToListAsync();

                response.Data = todos;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return response;
            }
        }
        public async Task<ServiceResponse<Todo>> FetchTodo(int userId, int todoId)
        {
            var response = new ServiceResponse<Todo>();

            try
            {
                var todo = await _context.Todos
                    .FirstOrDefaultAsync(t => t.Id == todoId && t.UserId == userId);

                if (todo == null)
                {
                    response.Success = false;
                    response.Message = "Not found";

                    return response;
                }

                response.Data = todo;

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return response;
            }
        }
        public async Task<ServiceResponse<Todo>> CreateTodo(int userId, Todo todo)
        {
            var response = new ServiceResponse<Todo>();

            try
            {
                todo.UserId = userId;

                await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();

                response.Data = todo;
                response.Message = "New task added.";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return response;
            }
        }
        public async Task<ServiceResponse<Todo>> UpdateTodo(int userId, Todo updatedTodo)
        {
            var response = new ServiceResponse<Todo>();

            try
            {
                var todo = await _context.Todos
                    .FirstOrDefaultAsync(t => t.Id == updatedTodo.Id && t.UserId == userId);

                if (todo == null)
                {
                    response.Success = false;
                    response.Message = "Not found";

                    return response;
                }

                todo.Title = updatedTodo.Title;
                todo.Status = updatedTodo.Status;
                todo.Timestamp = DateTime.Now;

                await _context.Todos.AddAsync(todo);
                await _context.SaveChangesAsync();

                response.Data = todo;
                response.Message = "Task updated successfully";

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                return response;
            }
        }
        public Task<ServiceResponse<bool>> DeleteTodo(int userId, int todoId)
        {
            throw new NotImplementedException();
        }
    }
}
