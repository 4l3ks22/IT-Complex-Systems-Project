import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

export default function TopRatedActorsGrid({ title = "Top Rated Actors" }) {
    const actors = [
        { id: 1, name: "Actor 1"},
        { id: 2, name: "Actor 2"},
        { id: 3, name: "Actor 3"},
        { id: 4, name: "Actor 4"},
        { id: 5, name: "Actor 5"},
    ];

    return (
        <Container className="mt-5">
            {/* Header Block */}
            <div className="mb-4">
                <h2 className="fw-bold">{title}</h2>
                <hr />
            </div>

            {/* Actor Grid */}
            <Row className="g-4">
                {actors.map(actor => (
                    <Col key={actor.id} xs={12} sm={6} md={4} lg={3} xl={2}>
                        <Card className="h-100">
                            <Card.Body>
                                <Card.Title>{actor.name}</Card.Title>
                                <Button variant="primary" className="w-100">
                                    View Profile
                                </Button>
                            </Card.Body>
                        </Card>
                    </Col>
                ))}
            </Row>
        </Container>
    );
}
