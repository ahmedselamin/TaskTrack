﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskTrack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("todos"), Authorize]
        public async Task<ActionResult> FetchTodos()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = await _todoService.FetchTodos(userId);

            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

        [HttpGet("{todoId:int}"), Authorize]
        public async Task<ActionResult> FetchTodo(int todoId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = await _todoService.FetchTodo(userId, todoId);

            return response.Success ? Ok(response) : BadRequest(response.Message);
        }

    }
}
