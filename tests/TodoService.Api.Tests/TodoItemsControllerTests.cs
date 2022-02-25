using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoService.Api.Controllers;
using TodoService.Application.Common.Mappers;
using TodoService.Application.DTO;
using TodoService.Application.TodoItems.Commands;
using TodoService.Application.TodoItems.Queries;
using TodoService.Domain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace TodoService.Api.Tests
{
    public class TodoItemsControllerTests
    {
        private Mock<IMediator>  _mockMediator;
        private IMapper _mapper;

        public TodoItemsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new TodoItemProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        #region Get todo item method
        [Fact]
        public async Task GetTodoItem_Ok_Result()
        {
            // Assert
            var request = 1;
            var expectedResult = new TodoItem(){Id = 1,Name = "Test Task", IsComplete = false}; 

            _mockMediator.Setup(x => x.Send(It.IsAny<GetTodoItemQuery>(), 
                                new CancellationToken())).ReturnsAsync(expectedResult);
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.GetTodoItem(request);

            //Assert
           Assert.Equal(expectedResult, ((ObjectResult)actualResult.Result).Value);
           Assert.IsType<OkObjectResult>(actualResult.Result);
            
        }
        
        [Fact]
        public async Task GetTodoItem_NotFound_Result()
        {
            // Assert
            var request = 1;

            _mockMediator.Setup(x => x.Send(It.IsAny<GetTodoItemQuery>(), 
                new CancellationToken())).ReturnsAsync((TodoItem) null);
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.GetTodoItem(request);
            
            //Assert
            Assert.IsType<NotFoundResult>(actualResult.Result);
        }
        #endregion

        #region Create todo item method
        [Fact]
        public async Task CreateTodoItem_Ok_Result()
        {
            // Assert
            var request = new TodoItemDTO(){Id = 0, Name = "Test Task", IsComplete = false};
            var createdEntity = new TodoItem(){Id = 1, Name = "Test Task", IsComplete = false}; 

            var expectedResult = new TodoItemDTO(){Id = 1, Name = "Test Task", IsComplete = false};


            _mockMediator.Setup(x => x.Send(It.IsAny<CreateTodoItemCommand>(), 
                new CancellationToken())).ReturnsAsync(createdEntity);
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.CreateTodoItem(request);

            //Assert
            Assert.Equivalent(expectedResult, (((ObjectResult)actualResult.Result).Value));
            Assert.IsType<OkObjectResult>(actualResult.Result);
        }
        
        [Fact]
        public async Task CreateTodoItem_BadRequest_Result()
        {
            // Assert
            var newTodoItem = new TodoItemDTO(){Id = 0, IsComplete = false};
            
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.CreateTodoItem(newTodoItem);

            //Assert
            Assert.IsType<BadRequestResult>(actualResult.Result);
        }
        #endregion

        #region Update todo item method
        [Fact]
        public async Task UpdateTodoItem_NotFound_Result()
        {
            // Assert
            var id = 1;
            var todoItem = new TodoItemDTO(){Id = 1, Name = "Test Task", IsComplete = false};

            _mockMediator.Setup(x => x.Send(It.IsAny<GetTodoItemQuery>(), 
                new CancellationToken())).ReturnsAsync((TodoItem) null);
            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateTodoItemCommand>(), 
                new CancellationToken())).ReturnsAsync(Unit.Value);
            
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.UpdateTodoItem(id, todoItem);

            //Assert
            Assert.IsType<NotFoundResult>(actualResult);
        }
        
        [Fact]
        public async Task UpdateTodoItem_BadRequest_Result()
        {
            // Assert
            var id = 1;
            var todoItem = new TodoItemDTO(){Id = 2, Name = "Test Task", IsComplete = false};

            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateTodoItemCommand>(), 
                new CancellationToken())).ReturnsAsync(null);
            
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.UpdateTodoItem(id, todoItem);

            //Assert
            Assert.IsType<BadRequestResult>(actualResult);
        }
        
        [Fact]
        public async Task UpdateTodoItem_NoContent_Result()
        {
            // Assert
            var id = 1;
            var todoItemDTO = new TodoItemDTO(){Id = 1, Name = "Test Task", IsComplete = false};
            var todoItemEntity = new TodoItem(){Id = 1, Name = "Test Task", IsComplete = false};


            _mockMediator.Setup(x => x.Send(It.IsAny<GetTodoItemQuery>(), 
                new CancellationToken())).ReturnsAsync(todoItemEntity);
            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateTodoItemCommand>(), 
                new CancellationToken())).ReturnsAsync(Unit.Value);
            
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.UpdateTodoItem(id, todoItemDTO);

            //Assert
            Assert.IsType<NoContentResult>(actualResult);
        }

        #endregion

        #region Delete todo item method
        [Fact]
        public async Task DeleteTodoItem_NoContent_Result()
        {
            // Assert
            var id = 1;
            var todoItem = new TodoItem(){Id = 1, Name = "Test Task", IsComplete = false};

            _mockMediator.Setup(x => x.Send(It.IsAny<GetTodoItemQuery>(), 
                new CancellationToken())).ReturnsAsync(todoItem);
            _mockMediator.Setup(x => x.Send(It.IsAny<DeleteTodoItemCommand>(), 
                new CancellationToken())).ReturnsAsync(Unit.Value);
            
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.DeleteTodoItem(id);

            //Assert
            Assert.IsType<NoContentResult>(actualResult);
        }
        
        [Fact]
        public async Task DeleteTodoItem_NotFound_Result()
        {
            // Assert
            var id = 2;

            _mockMediator.Setup(x => x.Send(It.IsAny<GetTodoItemQuery>(), 
                new CancellationToken())).ReturnsAsync((TodoItem) null);
            _mockMediator.Setup(x => x.Send(It.IsAny<DeleteTodoItemCommand>(), 
                new CancellationToken())).ReturnsAsync(Unit.Value);
            
            var controller = new TodoItemsController(_mockMediator.Object, _mapper);

            //Action
            var actualResult = await controller.DeleteTodoItem(id);

            //Assert
            Assert.IsType<NotFoundResult>(actualResult);
        }

        #endregion
    }
}