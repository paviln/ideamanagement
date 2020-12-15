import http from '../http-commen';
import authService from '../components/api-authorization/AuthorizeService';

const get = async (id) => {
  const token = await authService.getAccessToken();
  return http.get(`/task/${id}`, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

const post = async (ideaId, content) => {
  const token = await authService.getAccessToken();
  let formdata = new FormData();
  formdata.append('ideaId', ideaId);
  formdata.append('content', content);
  return http.post(`/task`, formdata, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

export default {
  get,
  post
};
