using AutoMapper;
using Hotel.Api.Models;
using Hotel.Attridute;
using Hotel.Infrastructures.Validator;
using Hotel.ModelsRequest.Person;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.ModelsRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;
        private readonly IApiValidatorService validatorService;

        public PersonController(IPersonService personService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.personService = personService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        [HttpGet, Authorize]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var login = User.Identity.Name;
            var result = await personService.GetAllAsync(cancellationToken);
            Console.WriteLine(login);
            return Ok(mapper.Map<IEnumerable<PersonResponse>>(result));
        }

        [HttpGet("{id:guid}")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await personService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти блюдо в меню с идентификатором {id}");
            }
            return Ok(mapper.Map<PersonResponse>(result));
        }

        [HttpPost("Register")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Create([FromForm] CreatePersonRequest createPersonRequest, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(createPersonRequest, cancellationToken);

            var personRequestModel = mapper.Map<PersonRequestModel>(createPersonRequest);
            var result = await personService.AddAsync(personRequestModel, cancellationToken);
            return Ok(mapper.Map<PersonResponse>(result));
        }

        [HttpPut]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Edit(EditPersonRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<PersonRequestModel>(request);
            var result = await personService.UpdateAsync(model, cancellationToken);
            return Ok(mapper.Map<PersonResponse>(result));
        }

        [HttpDelete("{id}")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await personService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
