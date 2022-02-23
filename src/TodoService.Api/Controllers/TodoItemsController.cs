using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Commands;
using TodoService.Application.TodoItems.Queries;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Persistense;

namespace TodoService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TodoItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get all Todo Items
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var result = await _mediator.Send(new GetAllTodoItemsQuery());
            return Ok(_mapper.Map<IEnumerable<TodoItemDTO>>(result));
        }
        
        /// <summary>
        /// Get certain item by id.
        /// </summary>
        /// <param name="id"></param>       
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await _mediator.Send(new GetTodoItemQuery(){Id = id});
            
            if (todoItem == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<TodoItemDTO>(todoItem));
        }

        /// <summary>
        /// Update Todo Item.
        /// </summary>
        /// <response code="400">If id doesn't equal to item id</response>
        /// <response code="404">Doesn't find object with such id to update</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }
            
            var todoItem = await _mediator.Send(new GetTodoItemQuery(){Id = id});
            if (todoItem == null)
            {
                return NotFound();
            }
            
            try
            {
                await _mediator.Send(new UpdateTodoItemCommand()
                {
                    Item = todoItem,
                    UpdatedItem = todoItemDTO
                });
            }
            catch (DbException ex)
            {
                if (await _mediator.Send(new GetTodoItemQuery(){Id = id}) == null)
                    return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Creates new Todo Item
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var entity = _mapper.Map<TodoItem>(todoItemDTO);
            var result = await _mediator.Send(new CreateTodoItemCommand() { Item = entity });
            
            return Ok(_mapper.Map<TodoItemDTO>(result));
        }

        /// <summary>
        /// Delete Todo Item by id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _mediator.Send(new GetTodoItemQuery() {Id = id});
            
            if (todoItem == null)
            {
                return NotFound();
            }

            await _mediator.Send(new DeleteTodoItemCommand(){ Item =  todoItem});

            return NoContent();
        }
    }
}
