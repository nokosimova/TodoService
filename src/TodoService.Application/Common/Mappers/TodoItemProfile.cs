using AutoMapper;
using TodoService.Application.DTO;
using TodoService.Domain.Entities;

namespace TodoService.Application.Common.Mappers
{
    public class TodoItemProfile: Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>();
            CreateMap<TodoItemDTO, TodoItem>();
        }
    }
}