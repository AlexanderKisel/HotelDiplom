using AutoMapper;
using Hotel.Api.Models;
using Hotel.Attridute;
using Hotel.Infrastructures.Validator;
using Hotel.ModelsRequest.Menu;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.ModelsRequest;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Menu")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;
        private readonly IMapper mapper;
        private readonly IApiValidatorService validatorService;

        public MenuController(IMenuService menuService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.menuService = menuService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        [HttpGet]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await menuService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<MenuResponse>>(result));
        }

        [HttpGet("{id:guid}")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await menuService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти блюдо в меню с идентификатором {id}");
            }
            return Ok(mapper.Map<MenuResponse>(result));
        }

        [HttpPost]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Create(CreateMenuRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var menuRequestModel = mapper.Map<MenuRequestModel>(request);
            var result = await menuService.AddAsync(menuRequestModel, cancellationToken);
            return Ok(mapper.Map<MenuResponse>(result));
        }

        [HttpPut]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Edit(EditMenuRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<MenuRequestModel>(request);
            var result = await menuService.UpdateAsync(model, cancellationToken);
            return Ok(mapper.Map<MenuResponse>(result));
        }

        [HttpDelete("{id}")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await menuService.DeleteAsync(id, cancellationToken);
            return Ok();
        }

    }
}
