import Carousel from "react-bootstrap/Carousel";

export default function NewestTitlesCarousel({ titles }) {
    if (!titles || titles.length === 0) return null;

    return (
        <Carousel>
            {titles.map(title => (
                <Carousel.Item key={title.url}>
                    <img
                        className="d-block w-100"
                        src={title.titleExtras?.poster}
                        alt={title.primarytitle}
                    />
                    <Carousel.Caption>
                        <h3>{title.primarytitle}</h3>
                        <p>{title.titleExtras?.plot}</p>
                    </Carousel.Caption>
                </Carousel.Item>
            ))}
        </Carousel>
    );
}
