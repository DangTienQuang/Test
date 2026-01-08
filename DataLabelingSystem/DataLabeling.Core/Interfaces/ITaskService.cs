using DataLabeling.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLabeling.Core.Interfaces
{
    public interface ITaskService
    {
        Task AssignTasksAsync(AssignTaskDto dto);
        Task<IEnumerable<TaskViewDto>> GetTasksByAnnotatorAsync(int annotatorId);
        Task SubmitLabelAsync(SubmitLabelDto dto);
        Task<IEnumerable<TaskViewDto>> GetSubmittedTasksAsync();
        Task ReviewTaskAsync(ReviewTaskDto dto);
    }
}