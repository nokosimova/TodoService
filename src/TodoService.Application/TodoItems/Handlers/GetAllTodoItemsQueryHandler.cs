using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Queries;
using TodoService.Domain.Entities;
using TodoService.Infrastructure.Repository;

namespace TodoService.Application.TodoItems.Handlers
{
    public class GetAllTodoItemsQueryHandler: IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDTO>>
    {
        private readonly IRepository<TodoItem> _repository;

        public GetAllTodoItemsQueryHandler(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TodoItemDTO>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}