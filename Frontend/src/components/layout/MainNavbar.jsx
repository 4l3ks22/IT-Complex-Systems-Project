import { useState } from 'react';
import { Link } from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';
import SearchBar from '../SearchBar';
import LoginPopUp from "../ui/LoginPopUp.jsx";
import ThemeButton from "../ThemeButton.jsx";

export default function MainNavbar() {
    const [showLogin, setShowLogin] = useState(false);

    const handleShow = () => setShowLogin(true);
    const handleClose = () => setShowLogin(false);

    return (
        <>
            <Navbar expand="lg" className="bg-body-tertiary py-1">
                <Container fluid>
                    <Row className="w-100 align-items-center">

                        {/* Logo */}
                        <Col xs="auto">
                            <Navbar.Brand as={Link} to="/">Movie DB</Navbar.Brand>
                        </Col>

                        {/* Search bar centered */}
                        <Col className="d-flex justify-content-center">
                            <div className="w-100 mt-3" style={{ maxWidth: "600px" }}>
                                <SearchBar />
                            </div>
                        </Col>

                        {/* Navigation + Sign In */}
                        <Col xs="auto">
                            <div className="d-flex align-items-center">
                                <Nav className="me-3">

                                    <Nav.Link as={Link} to="/">Home</Nav.Link>
                                    <Nav.Link as={Link} to="/titles">Titles</Nav.Link>
                                    <Nav.Link as={Link} to="/persons">Actors</Nav.Link>
                                    <Nav.Link as={Link} to="/genres">Advanced Search</Nav.Link>

                                </Nav>

                                <Button variant="outline-primary" onClick={handleShow}>
                                    Sign In
                                </Button>
                            </div>
                        </Col>

                        <Col xs="auto">
                            <ThemeButton />
                        </Col>
                    </Row>
                </Container>
            </Navbar>

            {/* Login modal */}
            <LoginPopUp show={showLogin} handleClose={handleClose} />
        </>
    );
}