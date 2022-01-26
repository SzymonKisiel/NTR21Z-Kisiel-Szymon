import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import './index.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';

import Page from './Page';
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

import { UserProvider } from './UserProvider';

function App() {
  return (
    <BrowserRouter><UserProvider>
      <Routes>
        <Route path="/" element={<Page />}>
          <Route index element={<></>} />
          <Route path="projects" element={<Projects />} />
          <Route path="details/:projectCode" element={<ProjectActivities />} />
          <Route path="manager" element={<Manager />} />
          <Route path="activities" element={<Activities />}>
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
      </UserProvider></BrowserRouter>
  );
};

export default App;