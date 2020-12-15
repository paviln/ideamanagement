import http from '../http-commen';
import authService from '../components/api-authorization/AuthorizeService';

const post = async (ideaId, postition, name) => {
  const token = await authService.getAccessToken();
  let formdata = new FormData();
  formdata.append('ideaId', ideaId);
  formdata.append('postition', postition);
  formdata.append('name', name);
  return http.post(`/employee`, formdata, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

export default {
  post
};
