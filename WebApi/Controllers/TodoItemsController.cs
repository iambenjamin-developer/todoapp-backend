using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }


        /// <summary>
        /// Gets all the TodoItems
        /// </summary>
        /// <returns>
        /// A collection of <see cref="ToDoItem"/> available
        /// </returns>
        /// <response code="200">Found successfully.</response>
        /// <response code="401">Your user account does not contain the authorization required to access this API end-point</response>
        /// <response code="403">Your user account does not have permission to access this resource</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ToDoItem>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _todoItemService.GetAllAsync();
            return new OkObjectResult(result);
        }


        /// <summary>
        /// Gets a ToDoItem by Id
        /// </summary>
        /// <returns>An instance of <see cref="ToDoItem"/></returns>
        /// <response code="200">Found successfully</response>
        /// <response code="401">Your user account does not contain the authorization required to access this API end-point</response>
        /// <response code="403">Your user account does not have permission to access this resource</response>
        /// <response code="404">Not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ToDoItem))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = null)]
        public async Task<ActionResult<ToDoItem>> GetById(int id)
        {
            var result = await _todoItemService.GetByIdAsync(id);

            if (result == null)
            {
                return new NotFoundObjectResult($"ToDoItem Id: { id } not found");
            }

            return new OkObjectResult(result);
        }


        /// <summary>
        /// Adds a ToDoItem to List
        /// </summary>
        /// <param name="addTodoItemDto">ToDoItem information to be created</param>
        /// <returns>
        ///  An instance of <see cref="ToDoItem"/>
        /// </returns>
        /// <response code="201">Added successfully</response>
        /// <response code="400">Bad request, invalid input information was supplied</response>
        /// <response code="401">Your user account does not contain the authorization required to access this API end-point</response>
        /// <response code="403">Your user account does not have permission to access this resource</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ToDoItem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = null)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
        public async Task<ActionResult> Post([FromBody] AddTodoItemDto addTodoItemDto)
        {
            if (string.IsNullOrEmpty(addTodoItemDto.Name) || addTodoItemDto.Name.Length < 3)
            {
                return new BadRequestObjectResult("Name must be at most 3 characters long");
            }

            var result = await _todoItemService.AddAsync(addTodoItemDto);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        }

        /// <summary>
        /// Deletes a ToDoItem by id
        /// </summary>
        /// <param name="id">ToDoItem identifier</param>
        /// <response code="204">Deleted successfully</response>
        /// <response code="401">Your user account does not contain the authorization required to access this API end-point</response>
        /// <response code="403">Your user account does not have permission to access this resource</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = null)]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _todoItemService.DeleteByIdAsync(id);

            if (result == false)
            {
                return new NotFoundObjectResult($"ToDoItem Id: { id } not found");
            }

            return new NoContentResult();
        }


        /// <summary>
        /// Updates the state of a ToDoItem 
        /// </summary>
        /// <param name="id">ToDoItem identifier</param>
        /// <param name="updateToDoItemDto">ToDoItem information to be updated</param>
        /// <response code="204">Updated successfully</response>
        /// <response code="401">Your user account does not contain the authorization required to access this API end-point</response>
        /// <response code="403">Your user account does not have permission to access this resource</response>
        /// <response code="404">Not found</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = null)]
        public async Task<ActionResult> UpdateById(int id, [FromBody] UpdateToDoItemDto updateToDoItemDto)
        {
            var result = await _todoItemService.UpdateByIdAsync(id, updateToDoItemDto);

            if (result == false)
            {
                return new NotFoundObjectResult($"ToDoItem Id: { id } not found");
            }

            return new NoContentResult();
        }



        /// <summary>
        /// Updates a range of ToDoItems
        /// </summary>
        /// <param name="updateRangeToDoItemsDto">ToDoItem Id's to be updated</param>
        /// <response code="204">Updated successfully</response>
        /// <response code="400">Bad request, invalid input information was supplied</response>
        /// <response code="401">Your user account does not contain the authorization required to access this API end-point</response>
        /// <response code="403">Your user account does not have permission to access this resource</response>
        [HttpPut]
        [Route("Range")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = null)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
        public async Task<ActionResult> UpdateRange([FromBody] UpdateRangeToDoItemsDto updateRangeToDoItemsDto)
        {
            if (updateRangeToDoItemsDto == null || updateRangeToDoItemsDto.ToDoItemIds.Count == 0)
            {
                return new BadRequestObjectResult("ToDoItemIds have to have at least one ToDoItem");
            }

            await _todoItemService.UpdateRangeToDoItemsAsync(updateRangeToDoItemsDto);

            return new NoContentResult();
        }


    }
}
