namespace Core.DTOs.Responses
{
    /// <summary>
    /// Standardized error response returned by the API when a request fails.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        /// <example>400</example>
        public int StatusCode { get; set; }

        /// <summary>
        /// A descriptive message explaining the error.
        /// </summary>
        /// <example>Validation failed.</example>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Optional additional details about the error, such as a stack trace in development environments.
        /// </summary>
        public string? Details { get; set; }
    }
}
