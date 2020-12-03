import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import registerServiceWorker from './registerServiceWorker';
import axios from 'axios';
import App from './App';
import SiteService from './services/SiteService';
import NoAccess from './components/NoAccess';

axios.defaults.baseURL = 'https://localhost:8000/';
axios.defaults.headers.common['Authorization'] = 'Bearer ' + localStorage.getItem('token');



var baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

/* var url = window.location.href;
url = url.split("/");
url = url[3];

if (url != "") {
  SiteService.findByLink(url)
  .then(result => {
    if (result.data.link === url) {
      baseUrl = baseUrl.concat(url);
      renderSite();
    }
    else {
      noAccess();
    }
  })
  .catch(error => {
    noAccess();
  })
}

function renderSite() {
  ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
      <App />
    </BrowserRouter>,
    rootElement);
}

function noAccess() {
  ReactDOM.render(
    <NoAccess></NoAccess>,
    rootElement);
} */

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();