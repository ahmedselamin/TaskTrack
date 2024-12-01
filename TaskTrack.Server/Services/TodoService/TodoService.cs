
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
        public Task<ServiceResponse<Todo>> FetchTodo(int userId, int todoId)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Todo>> CreateTodo(int userId, Todo todo)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Todo>> UpdateTodo(int userId, Todo todo)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<bool>> DeleteTodo(int userId, int todoId)
        {
            throw new NotImplementedException();
        }
    }
}
