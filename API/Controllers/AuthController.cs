using BLL.Interfaces;
using Core.DTOs.Requests;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Provides APIs for user authentication and account registration.
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    [Tags("1. Authentication")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers a new user account.
        /// </summary>
        /// <remarks>
        /// This endpoint creates a new user with a specific role
        /// (e.g., Annotator, Reviewer, Manager, Admin).
        /// </remarks>
        /// <param name="request">
        /// The registration request containing:
        /// - Full name
        /// - Email address
        /// - Password
        /// - Role
        /// </param>
        /// <returns>
        /// A confirmation message and the newly created user's unique identifier.
        /// </returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = await _userService.RegisterAsync(
                    request.FullName,
                    request.Email,
                    request.Password,
                    request.Role
                );

                return Ok(new
                {
                    Message = "Registration successful",
                    UserId = user.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Authenticates a user and issues a JWT access token.
        /// </summary>
        /// <remarks>
        /// The returned JWT token must be included in the
        /// <c>Authorization</c> header as:
        /// <br />
        /// <c>Authorization: Bearer {token}</c>
        /// </remarks>
        /// <param name="request">
        /// The login request containing the user's email and password.
        /// </param>
        /// <returns>
        /// A JWT access token along with token metadata.
        /// </returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _userService.LoginAsync(request.Email, request.Password);

                if (token == null)
                {
                    return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "Invalid email or password" });
                }

                return Ok(new
                {
                    Message = "Login successful",
                    AccessToken = token,
                    TokenType = "Bearer"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}
