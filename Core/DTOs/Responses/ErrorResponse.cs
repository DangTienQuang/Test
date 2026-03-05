namespace Core.DTOs.Responses
{
    /// <summary>
    /// Standardized error response for 400 and 401 error codes.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// A descriptive error message.
        /// </summary>
        /// <example>Invalid email or password.</example>
        public string Message { get; set; } = string.Empty;
    }
}
