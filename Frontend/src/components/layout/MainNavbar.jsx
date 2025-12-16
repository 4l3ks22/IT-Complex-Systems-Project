import { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Dropdown from 'react-bootstrap/Dropdown';
import SearchBar from '../SearchBar';
import LoginPopUp from "../ui/LoginPopUp.jsx";
import ThemeButton from "../ThemeButton.jsx";

export default function MainNavbar() {
    const [showLogin, setShowLogin] = useState(false);
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    const handleShow = () => setShowLogin(true);
    const handleClose = () => setShowLogin(false);

    const handleLogout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("userId");
        localStorage.removeItem("username");
        setUser(null);
        navigate('/'); // redirect to main page
    };

    useEffect(() => {
        const token = localStorage.getItem("token");
        const username = localStorage.getItem("username");
        const userIdStr = localStorage.getItem("userId");

        const userId = userIdStr ? parseInt(userIdStr, 10) : null;

        if (token && username && userId !== null && !isNaN(userId)) {
            setUser({ username, userId });
        }
    }, []);

    return (
        <>
            <Navbar expand="lg" bg="light" className="py-2  shadow-sm fixed-top">
                <div className="container-fluid p-2">
                    <Navbar.Brand as={Link} to="/">Movie DB</Navbar.Brand>

                    <div className="m-auto px-2" style={{ maxWidth: '500px', flex: 1 }}>
                        <SearchBar />
                    </div>

                    <Nav className="d-flex align-items-center justify-content-end flex-wrap">
                        <Nav.Link as={Link} to="/">Home</Nav.Link>
                        <Nav.Link as={Link} to="/titles">Titles</Nav.Link>
                        <Nav.Link as={Link} to="/persons">Actors</Nav.Link>
                        <Nav.Link as={Link} to="/genres">Advanced Search</Nav.Link>

                        {user && (
                            <>
                                <Nav.Link as={Link} to={`/users/${user.userId}/ratings`}>
                                    My Ratings
                                </Nav.Link>
                                <Nav.Link as={Link} to={`/bookmarks/${user.userId}`}>
                                    Bookmarks
                                </Nav.Link>
                            </>
                        )}

                        {user ? (
                            <Dropdown align="end" className="ms-2">
                                <Dropdown.Toggle variant="outline-primary">
                                    {user.username}
                                </Dropdown.Toggle>
                                <Dropdown.Menu>
                                    <Dropdown.Item onClick={handleLogout}>Logout</Dropdown.Item>
                                </Dropdown.Menu>
                            </Dropdown>
                        ) : (
                            <Button variant="outline-primary" className="ms-2" onClick={handleShow}>
                                Sign In
                            </Button>
                        )}

                        <ThemeButton className="ms-2" />
                    </Nav>
                </div>
            </Navbar>

            <LoginPopUp show={showLogin} handleClose={handleClose} setUser={setUser} />
        </>
    );
}