using AutoMapper;
using Hotel.Api.Models;
using Hotel.Attridute;
using Hotel.Infrastructures.Validator;
using Hotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{



    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Autorization")]
    public class AutorizationController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        private readonly IApiValidatorService validatorService;

        public AutorizationController(ITokenService tokenService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.tokenService = tokenService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        [HttpPost("Auth")]
        [ApiOk]
        [ApiNotFound]
        public async Task<IActionResult> AutorizationPerson(string login, string password, CancellationToken cancellationToken)
        {
            var result = await tokenService.AutorizationPerson(login, password, cancellationToken);
            return Ok(mapper.Map<AuthResponse>(result));
        }
    }
}
