import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";

export default function TopRatedTitlesGrid({ titles }) {
    if (!titles || titles.length === 0) return null;

    return (
        <div className="grid-container">
            <Row>
            {titles.map(title => (
                <Col>
                <div key={title.url} className="grid-item">
                    <img
                        src={title.titleExtras?.poster}
                        alt={title.primarytitle}
                    />
                    <h4>{title.primarytitle}</h4>
                    <p>Rating: {title.titleRating?.averagerating}</p>
                    <p>{title.startyear}</p>
                </div>
                </Col>
            ))}
            </Row>
        </div>

        
    );
}
