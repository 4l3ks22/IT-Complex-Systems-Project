import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";

export default function TopRatedTitlesGrid({ titles }) {
    if (!titles || titles.length === 0) return null;

    return (
        <>
        <div>
            <h1 className="text-start mt-4 mb-3 px-3 py-2">Top Rated Titles</h1>
        </div>
        <div className="grid-container">
            <Row className="row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-2">
                {titles.map(title => (
                    <Col key={title.url}>
                        <div className="card h-100">
                            {title.titleExtras?.poster && (
                                <img
                                    src={title.titleExtras.poster}
                                    alt={title.primarytitle}
                                    className="card-img-top card-img-fixed"   
                                />
                            )}
                            <div className="card-body d-flex flex-column">
                                <h5 className="card-title">{title.primarytitle}</h5>
                                <p className="card-text mb-1">
                                    Rating: {title.titleRating?.averagerating}
                                </p>
                                <p className="card-text text-muted">{title.startyear}</p>
                            </div>
                        </div>
                    </Col>
                ))}
            </Row>
        </div>
        </>


    );
}