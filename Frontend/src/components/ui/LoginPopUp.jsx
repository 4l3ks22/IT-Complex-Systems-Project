import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

export default function LoginPopUp({ show, handleClose }) {

    const handleLogin = (e) => {
        e.preventDefault();
        // call login API 
        console.log("Logging in...");
        handleClose();
    };

    return (
        <Modal show={show} onHide={handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>Sign In</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={handleLogin}>
                    <Form.Group className="mb-3" controlId="formEmail">
                        <Form.Label>Email address</Form.Label>
                        <Form.Control type="email" placeholder="Enter email" required />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Enter Password" required />
                    </Form.Group>

                    <Button variant="primary" type="submit" className="w-100 mb-3">
                        Sign In
                    </Button>

                    <div className="text-center">
                        <span>
                            Not a user?{" "}
                            <Button
                                variant="link"
                                href="/register" // redirect to registration page
                                className="p-0"
                            >
                                Register here
                            </Button>
                        </span>
                    </div>
                </Form>
            </Modal.Body>
        </Modal>
    );
}
