import { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Button from 'react-bootstrap/Button';
import SearchBar from '../SearchBar';
import LoginPopUp from "../ui/LoginPopUp.jsx";

export default function MainNavbar() {
    const [showLogin, setShowLogin] = useState(false);

    const handleShow = () => setShowLogin(true);
    const handleClose = () => setShowLogin(false);

    return (
        <>
            <Navbar expand="lg" className="bg-body-tertiary py-2">
                <Container fluid>
                    <Row className="w-100 align-items-center">
                        {/* Logo */}
                        <Col xs="auto">
                            <Navbar.Brand href="/">Movie DB</Navbar.Brand>
                        </Col>

                        {/* Search bar centered and flexible */}
                        <Col className="d-flex justify-content-center">
                            <div className="w-100" style={{ maxWidth: "600px" }}>
                                <SearchBar />
                            </div>
                        </Col>

                        {/* Nav links + Sign In */}
                        <Col xs="auto">
                            <div className="d-flex align-items-center">
                                <Nav className="me-3">
                                    <Nav.Link href="/">Home</Nav.Link>
                                    <Nav.Link href="/movies">Movies</Nav.Link>
                                    <Nav.Link href="/actors">Actors</Nav.Link>
                                </Nav>
                                <Button variant="outline-primary" onClick={handleShow}>
                                    Sign In
                                </Button>
                            </div>
                        </Col>
                    </Row>
                </Container>
            </Navbar>

            {/* Login modal */}
            <LoginPopUp show={showLogin} handleClose={handleClose} />
        </>
    );
}
