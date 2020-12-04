import http from '../http-commen';

const getSite = () => {
  return http.get(`/applicationuser/getsite`);
};

export default {
  getSite
};
