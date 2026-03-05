using BLL.Interfaces;
using Core.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    [Authorize]
    [Tags("3. Project Management")]
    public class ProjectDataController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IWebHostEnvironment _env;

        public ProjectDataController(IProjectService projectService, IWebHostEnvironment env)
        {
            _projectService = projectService;
            _env = env;
        }

        /// <summary>
        /// Import data items from external URLs into a project.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="projectId">The project ID.</param>
        /// <param name="request">Payload containing storage URLs.</param>
        /// <response code="200">Data items imported successfully.</response>
        /// <response code="400">Import failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost("{projectId}/import")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> ImportData(int projectId, [FromBody] ImportDataRequest request)
        {
            try
            {
                await _projectService.ImportDataItemsAsync(projectId, request.StorageUrls);
                return Ok(new { Message = "Data items imported successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Direct upload data items (files) to a project.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="projectId">The project ID.</param>
        /// <param name="files">List of image files to upload.</param>
        /// <response code="200">Files uploaded successfully.</response>
        /// <response code="400">Upload failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost("{projectId}/upload-direct")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> UploadDirect(int projectId, [FromForm] List<IFormFile> files)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            if (files == null || !files.Any())
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = "Please select at least one file to upload." });

            try
            {
                var webRootPath = _env.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                var uploadedCount = await _projectService.UploadDirectDataItemsAsync(projectId, files, webRootPath);
                return Ok(new { Message = $"{uploadedCount} files uploaded successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get buckets of assigned data items for a specific project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <response code="200">Buckets retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("{projectId}/buckets")]
        [Authorize(Roles = "Annotator,Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetBuckets(int projectId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var buckets = await _projectService.GetBucketsAsync(projectId, userId);
            return Ok(buckets);
        }

        /// <summary>
        /// Export project data including annotations.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="projectId">The project ID.</param>
        /// <response code="200">Data exported successfully as a JSON file.</response>
        /// <response code="400">Export failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("{projectId}/export")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(FileContentResult), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> ExportData(int projectId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            try
            {
                var fileContent = await _projectService.ExportProjectDataAsync(projectId, userId);
                var fileName = $"project_{projectId}_export_{DateTime.UtcNow:yyyyMMdd}.json";
                return File(fileContent, "application/json", fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}