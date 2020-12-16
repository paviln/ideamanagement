import http from '../http-commen';
import authService from '../components/api-authorization/AuthorizeService';

const post = async (ideaId, content) => {
  const token = await authService.getAccessToken();
  let formdata = new FormData();
  formdata.append('ideaId', ideaId);
  formdata.append('content', content);
  return http.post(`/task`, formdata, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

const saveComment = async (taskId, comment) => {
  const token = await authService.getAccessToken();
  let formdata = new FormData();
  formdata.append('taskId', taskId);
  formdata.append('comment', comment);
  return http.post(`/task/comment`, formdata, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

const update = async (id, task) => {
  const token = await authService.getAccessToken();
  return http.put(`/task/${id}`, task, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

export default {
  post,
  saveComment,
  update
};
