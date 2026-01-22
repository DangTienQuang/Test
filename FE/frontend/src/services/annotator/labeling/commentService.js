import axios from "../../axios.customize";

const commentService = {
  getComments: (taskId) => {
    return axios.get(`/api/Review/project/${taskId}`);
  },

  postComment: (taskId, content) => {
    return axios.post(`/api/Review`, {
      projectId: taskId,
      comment: content,
      errorCategory: "General",
    });
  },
};

export default commentService;
