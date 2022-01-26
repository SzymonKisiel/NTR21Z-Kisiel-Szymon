import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import reportWebVitals from './reportWebVitals';

import './index.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';

import App from './App';
import Projects from './Projects';
import Manager from './Manager';
import Activities from './Activities';
import Login from './Login';
import Logo from './Logo';
import ProjectAdd from './ProjectAdd';
import ProjectEdit from './ProjectEdit';
import ActivityAdd from './ActivityAdd';
import ActivityEdit from './ActivityEdit';
import ProjectActivities from './ProjectActivities';

import UserProvider from './UserProvider';

ReactDOM.render(
  <UserProvider>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />}>
          <Route index element={<p>index</p>} />
          <Route path="projects" element={<Projects />}>
            {/* <Route path="add" element={<Logo />} />
            <Route path="edit" element={<Logo />} /> */}
          </Route>
          <Route path="details/:projectCode" element={<ProjectActivities />} />
          <Route path="manager" element={<Manager />} />
          <Route path="activities" element={<Activities />}>
            {/* <Route path="add" element={<Logo />} />
            <Route path="edit" element={<Logo />} /> */}
            <Route path=":type" element={<Activities />} />
          </Route>
          <Route path="logo" element={<Logo />} />
          <Route path="login" element={<Login />} />
          <Route path="*" element={<p>default</p>} />
          <Route path="addactivity" element={<ActivityAdd />} />
          <Route path="editactivity" element={<ActivityEdit />} />
          <Route path="addproject" element={<ProjectAdd />} />
          <Route path="editproject/:code" element={<ProjectEdit />} />
        </Route>
      </Routes>
    </BrowserRouter>
  </UserProvider>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
