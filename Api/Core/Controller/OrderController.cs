using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sampleDotnetCoreApi.Api.Core.Models.Request;
using sampleDotnetCoreApi.Services.IServices;

namespace sampleDotnetCoreApi.Api.Core.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _cartService;
        private readonly IValidator<int> _orderIdValidator;
        private readonly IValidator<CreateOrderRequest> _createOrderRequestValidator;

        public OrderController(IOrderService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _cartService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var validationResult = _orderIdValidator.Validate(id);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = _cartService.GetBy(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest createOrderRequest)
        {
            var validationResult = _createOrderRequestValidator.Validate(createOrderRequest);
            if (validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var result = _cartService.Create(createOrderRequest);

            return Ok(result);
        }
    }
}