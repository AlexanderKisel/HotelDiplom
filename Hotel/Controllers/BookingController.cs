using AutoMapper;
using Hotel.Api.Models;
using Hotel.Attridute;
using Hotel.Infrastructures.Validator;
using Hotel.ModelsRequest.Booking;
using Hotel.Services.Contracts.Interface;
using Hotel.Services.Contracts.ModelsRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Booking")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly IMapper mapper;
        private readonly IApiValidatorService validatorService;

        public BookingController(IBookingService bookingService, IMapper mapper, IApiValidatorService validatorService)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        [HttpGet("[action]")]
        [ApiOk]
        public async Task<IActionResult> GetFilteredBookings(CancellationToken cancellationToken)
        {
            var userId = Request.Cookies["userId"];
            if (userId == null)
            {
                return BadRequest(new { message = "UserId не найден в cookie" });
            }

            var bookings = await bookingService.GetFilteredBookingsAsync(userId, cancellationToken);

            return Ok(mapper.Map<IEnumerable<BookingResponse>>(bookings));
        }

        [HttpGet("[action]")]
        [ApiOk]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await bookingService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<BookingResponse>>(result));
        }

        [HttpGet("{id:guid}"), Authorize]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> GetById([Required] Guid id, CancellationToken cancellationToken)
        {
            var result = await bookingService.GetByIdAsync(id, cancellationToken);
            if (result == null)
            {
                return NotFound($"Не удалось найти бронирование с идентификатором {id}");
            }
            return Ok(mapper.Map<BookingResponse>(result));
        }

        [HttpPost("[action]")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Create(CreateBookingRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var bookingRequestModel = mapper.Map<BookingRequestModel>(request);
            var result = await bookingService.AddAsync(bookingRequestModel, cancellationToken);
            return Ok(mapper.Map<BookingResponse>(result));
        }

        [HttpPut, Authorize(Roles = "Admin")]
        [ApiOk]
        public async Task<IActionResult> Edit(EditBookingRequest request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<BookingRequestModel>(request);
            var result = await bookingService.UpdateAsync(model, cancellationToken);
            return Ok(mapper.Map<BookingResponse>(result));
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        [ApiOk]
        [ApiConflict]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await bookingService.DeleteAsync(id, cancellationToken);
            return Ok();
        }

    }
}
