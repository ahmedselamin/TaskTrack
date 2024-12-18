﻿namespace TaskTrack.Server.Services.TodoService
{
    public interface ITodoService
    {
        Task<ServiceResponse<List<Todo>>> FetchTodos(int userId);
        Task<ServiceResponse<Todo>> FetchTodo(int userId, int todoId);
        Task<ServiceResponse<Todo>> CreateTodo(int userId, CreateTodoDTO newTodo);
        Task<ServiceResponse<Todo>> UpdateTodo(int userId, int todoId, UpdateTodoDTO updatedTodo);
        Task<ServiceResponse<bool>> DeleteTodo(int userId, int todoId);
    }
}
