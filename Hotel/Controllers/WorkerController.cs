using AutoMapper;
using Hotel.Api.Models;
using Hotel.Attridute;
using Hotel.Infrastructures.Validator;
using Hotel.ModelsRequest.Room;
using Hotel.ModelsRequest.Worker;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.ModelsRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Worker")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService workerService;
        private readonly IMapper mapper;
        private readonly IApiValidatorService validatorService;

        public WorkerController(IWorkerService workerService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.workerService = workerService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await workerService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<WorkerResponse>>(result));
        }

        [HttpGet("{id:guid}"), Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await workerService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти блюдо в меню с идентификатором {id}");
            }
            return Ok(mapper.Map<WorkerResponse>(result));
        }

        [HttpPost, Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Create(CreateWorkerRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var workerRequestModel = mapper.Map<WorkerRequestModel>(request);
            var result = await workerService.AddAsync(workerRequestModel, cancellationToken);
            return Ok(mapper.Map<WorkerResponse>(result));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Edit(EditWorkerRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<WorkerRequestModel>(request);
            var result = await workerService.UpdateAsync(model, cancellationToken);
            return Ok(mapper.Map<WorkerResponse>(result));
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await workerService.DeleteAsync(id, cancellationToken);
            return Ok();
        }

    }
}
