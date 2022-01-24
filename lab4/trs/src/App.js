import './App.css';
import React, { useEffect, useContext } from 'react';
import { Outlet } from 'react-router-dom'
import { Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';

import UserContext from './UserContext';

const title = "Time Reporting System";

function App() {
  const { username, isLoggedIn, logout } = useContext(UserContext);

  useEffect(() => {
    document.title = title;
  }, []);

  return (
    <div>
      <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
        <Container>
        <Navbar.Brand href="/">{title}</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/projects">Projects</Nav.Link>
            <Nav.Link href="/manager">My Projects</Nav.Link>
            <NavDropdown title="My Activities" id="collasible-nav-dropdown">
              <NavDropdown.Item href="/activities/day">Day</NavDropdown.Item>
              <NavDropdown.Item href="/activities/month">Month</NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Nav variant="pills">
            {
              isLoggedIn
              ? <>
                <Navbar.Text>Logged in as {username}</Navbar.Text>,
                <Nav.Link onClick={logout}>Logout</Nav.Link>
                {/* <input type="button" onClick={logout} value="Logout" /> */}
                </>
              :
                <>
                <Navbar.Text>Not logged in</Navbar.Text>
                <Nav.Link href="/login">Login</Nav.Link>
                </>
            }
          </Nav>
        </Navbar.Collapse>
        </Container>
      </Navbar>
       <Outlet />
     </div>
  );
};

export default App;
