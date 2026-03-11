using Fit3d.BLL.Common;
using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using FIt3d.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Fit3d.API.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseData<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest request, CancellationToken cancellationToken)
        {
            var result = await _paymentService.CreatePayment(request, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("return")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PaymentReturn([FromQuery] Guid orderId, CancellationToken cancellationToken)
        {
            var result = await _paymentService.PaymentReturn(orderId, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("cancel")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PaymentCancel([FromQuery] Guid orderId, CancellationToken cancellationToken)
        {
            var result = await _paymentService.PaymentCancel(orderId, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("subscription/plans")]
        [ProducesResponseType(typeof(ResponseData<List<SubscriptionPlanResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubscriptionPlans([FromQuery] PlanType planType, CancellationToken cancellationToken)
        {
            var result = await _paymentService.GetSubscriptionPlansByType(planType, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPost("subscription/create")]
        [ProducesResponseType(typeof(ResponseData<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubscriptionPayment([FromBody] SubscriptionPaymentRequest request, CancellationToken cancellationToken)
        {
            var result = await _paymentService.CreateSubscriptionPayment(request, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("subscription/return")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubscriptionPaymentReturn([FromQuery] Guid subscriptionId, CancellationToken cancellationToken)
        {
            var result = await _paymentService.SubscriptionPaymentReturn(subscriptionId, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpGet("subscription/cancel")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SubscriptionPaymentCancel([FromQuery] Guid subscriptionId, CancellationToken cancellationToken)
        {
            var result = await _paymentService.SubscriptionPaymentCancel(subscriptionId, cancellationToken);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
