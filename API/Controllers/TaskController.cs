using BLL.Interfaces;
using Core.DTOs.Requests;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    /// <summary>
    /// Controller for managing annotation tasks,
    /// including task assignment by Managers and task execution by Annotators.
    /// </summary>
    [Route("api/tasks")]
    [ApiController]
    [Authorize]
    [Tags("4. Task & Annotation")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // ======================================================
        // MANAGER APIs
        // ======================================================

        /// <summary>
        /// (Manager) Assign annotation tasks to an Annotator and a Reviewer.
        /// </summary>
        /// <param name="request">
        /// Assignment information including ProjectId, AnnotatorId, ReviewerId, and number of images.
        /// </param>
        /// <returns>Assignment result message.</returns>
        /// <response code="200">Tasks assigned successfully.</response>
        /// <response code="400">Assignment failed (e.g. insufficient images, user not found).</response>
        /// <response code="401">User is not authorized as Manager.</response>
        [HttpPost("assign")]
        [Authorize(Roles = "Manager")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> AssignTasks([FromBody] AssignTaskRequest request)
        {
            try
            {
                await _taskService.AssignTasksToAnnotatorAsync(request);
                return Ok(new { Message = "Tasks assigned successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
        /// <summary>
        /// Get tasks by bucket ID within a project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <param name="bucketId">The bucket ID.</param>
        /// <response code="200">Tasks retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("project/{projectId}/bucket/{bucketId}")]
        [Authorize(Roles = "Annotator,Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetTasksByBucket(int projectId, int bucketId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var tasks = await _taskService.GetTasksByBucketAsync(projectId, bucketId, userId);
            return Ok(tasks);
        }
        // ======================================================
        // ANNOTATOR - DASHBOARD APIs
        // ======================================================

        /// <summary>
        /// (Annotator - Dashboard) Get list of assigned projects.
        /// </summary>
        /// <remarks>
        /// Used on the main Dashboard screen.
        /// Assignments are grouped into Project Cards.
        /// Returns overall progress, deadline, and project status.
        /// </remarks>
        /// <returns>List of projects assigned to the current user.</returns>
        /// <response code="200">Projects retrieved successfully.</response>
        /// <response code="401">User is not authenticated.</response>
        [HttpGet("my-projects")]
        [ProducesResponseType(typeof(List<AssignedProjectResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetMyProjects()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            var projects = await _taskService.GetAssignedProjectsAsync(userId);
            return Ok(projects);
        }

        // ======================================================
        // ANNOTATOR - WORK AREA APIs
        // ======================================================
        /// <summary>
        /// Submits multiple annotation tasks at once (Batch Submit).
        /// </summary>
        /// <remarks>
        /// Only applies to users with 'Annotator' role.
        /// Ignores tasks that do not have draft annotations saved.
        /// </remarks>
        /// <param name="request">Payload containing a list of Assignment IDs to submit.</param>
        /// <response code="200">Tasks submitted successfully.</response>
        /// <response code="400">Submission failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost("batch-submit")]
        [Authorize(Roles = "Annotator")]
        [ProducesResponseType(typeof(SubmitMultipleTasksResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> SubmitMultipleTasks([FromBody] SubmitMultipleTasksRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            if (request.AssignmentIds == null || !request.AssignmentIds.Any())
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Assignment list cannot be empty." });

            try
            {
                var result = await _taskService.SubmitMultipleTasksAsync(userId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
        /// <summary>
        /// (Annotator - Work Area) Get all images (assignments) of a project.
        /// </summary>
        /// <remarks>
        /// Called when the user enters a project.
        /// Returns the full assignment list so FE can handle Next / Previous navigation.
        /// </remarks>
        /// <param name="projectId">Target project ID.</param>
        /// <returns>List of assignments with status and existing annotation data.</returns>
        /// <response code="200">Images retrieved successfully.</response>
        /// <response code="401">User is not authenticated.</response>
        [HttpGet("project/{projectId}/images")]
        [ProducesResponseType(typeof(List<AssignmentResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetProjectImages(int projectId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            var images = await _taskService.GetTaskImagesAsync(projectId, userId);
            return Ok(images);
        }

        /// <summary>
        /// (Annotator) Jump to a specific image inside a project.
        /// </summary>
        /// <remarks>
        /// Used for navigation scenarios such as:
        /// - Clicking an error notification
        /// - Refreshing the page (F5)
        /// </remarks>
        /// <param name="projectId">Project ID.</param>
        /// <param name="dataItemId">Target data item ID.</param>
        /// <returns>Assignment detail.</returns>
        /// <response code="400">Jump failed.</response>
        /// <response code="401">User is not authenticated.</response>
        [HttpGet("project/{projectId}/jump/{dataItemId}")]
        [ProducesResponseType(typeof(AssignmentResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> JumpToImage(int projectId, int dataItemId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            try
            {
                var result = await _taskService.JumpToDataItemAsync(projectId, dataItemId, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// (Annotator) Get a single assignment by AssignmentId.
        /// </summary>
        /// <remarks>
        /// Used when navigating directly to a specific image.
        /// </remarks>
        /// <param name="id">Assignment ID.</param>
        /// <returns>Assignment detail including image and annotation data.</returns>
        /// <response code="400">Failed to get assignment.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="404">Assignment not found.</response>
        [HttpGet("assignment/{id}")]
        [ProducesResponseType(typeof(AssignmentResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetSingleAssignment(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            try
            {
                var assignment = await _taskService.GetAssignmentByIdAsync(id, userId);
                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        // ======================================================
        // ANNOTATOR - SAVE & SUBMIT APIs
        // ======================================================

        /// <summary>
        /// (Annotator) Save annotation draft.
        /// </summary>
        /// <remarks>
        /// Called when the user clicks "Next" or "Save".
        /// Updates annotation data (DataJSON) and sets status to 'InProgress'.
        /// </remarks>
        /// <param name="request">
        /// Contains AssignmentId and annotation data (Canvas JSON).
        /// </param>
        /// <returns>Save result.</returns>
        /// <response code="200">Draft saved successfully.</response>
        /// <response code="400">Invalid input data.</response>
        [HttpPost("draft")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> SaveDraft([FromBody] SubmitAnnotationRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            try
            {
                await _taskService.SaveDraftAsync(userId, request);
                return Ok(new { Message = "Draft saved successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// (Annotator) Submit annotation for review.
        /// </summary>
        /// <remarks>
        /// Called when the user clicks "Submit".
        /// Updates annotation data and sets status to 'Submitted'.
        /// </remarks>
        /// <param name="request">
        /// Contains AssignmentId and final annotation data.
        /// </param>
        /// <returns>Submit result.</returns>
        /// <response code="200">Task submitted successfully.</response>
        /// <response code="400">Submission failed.</response>
        /// <response code="401">User is not authenticated.</response>
        [HttpPost("submit")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> SubmitTask([FromBody] SubmitAnnotationRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            try
            {
                await _taskService.SubmitTaskAsync(userId, request);
                return Ok(new { Message = "Task submitted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}