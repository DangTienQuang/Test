import axiosInstance from "../../axios.customize";
const taskService = {
  getMyTasks: () => {
    return axiosInstance.get(`/api/Task/my-tasks`);
  },
  getTaskDetail: (assignmentId) => {
    return axiosInstance.get(`/api/Task/detail/${assignmentId}`);
  },

  getProjectLabels: (projectId) => {
    return axiosInstance.get(`/api/Project/${projectId}`);
  },

  submitTask: (assignmentId, annotations) => {
    return axiosInstance.post(`/api/Task/submit`, {
      assignmentId,
      annotations,
      status: "Submitted",
    });
  },
};

export default taskService;
