using AutoMapper;
using Hotel.Api.Models;
using Hotel.Attridute;
using Hotel.Infrastructures.Validator;
using Hotel.ModelsRequest.Room;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.ModelsRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;
        private readonly IApiValidatorService validatorService;

        public RoomController(IRoomService roomService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.roomService = roomService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        [HttpGet("[action]")]
        [ApiOk]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await roomService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<RoomResponse>>(result));
        }

        [HttpGet("{id:guid}")]
        [ApiOk]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await roomService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти блюдо в меню с идентификатором {id}");
            }
            return Ok(mapper.Map<RoomResponse>(result));
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Create(CreateRoomRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var roomRequestModel = mapper.Map<RoomRequestModel>(request);
            var result = await roomService.AddAsync(roomRequestModel, cancellationToken);
            return Ok(mapper.Map<RoomResponse>(result));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Edit(EditRoomRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<RoomRequestModel>(request);
            var result = await roomService.UpdateAsync(model, cancellationToken);
            return Ok(mapper.Map<RoomResponse>(result));
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await roomService.DeleteAsync(id, cancellationToken);
            return Ok();
        }

    }
}
