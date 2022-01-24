import './App.css';
import React, { useState, useEffect } from 'react';
import { Link, Outlet } from 'react-router-dom'
import { Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import { Button } from 'react'

const title = "Time Reporting System";

function App() {

  const [isLoggedIn, setLoggedIn] = useState(false);
  const [username, setUsername] = useState("");

  useEffect(() => {
    document.title = title;
  }, []);

  function logout() {
    alert("test");
    // console.log("logout");
    // setUsername("");
    // setLoggedIn(false);
  };

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
          {
            isLoggedIn
            ? <Nav>
                <Nav.Link>Logged in as {username}</Nav.Link>,
                <Nav.Link onClick={logout}>Logout</Nav.Link>
                <input type="button" onClick={logout} value="Logout" />
              </Nav>
            : <Nav>
                <Nav.Link>Not logged in</Nav.Link>
                <Nav.Link>Login</Nav.Link>
              </Nav>
          }
        </Navbar.Collapse>
        </Container>
      </Navbar>
       <Outlet />
     </div>
  );
}

export default App;
