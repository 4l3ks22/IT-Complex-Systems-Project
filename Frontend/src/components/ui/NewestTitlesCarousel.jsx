import Carousel from "react-bootstrap/Carousel";

export default function NewestTitlesCarousel({ titles }) {
    if (!titles || titles.length === 0) return null;

    return (
        <Carousel data-bs-theme="dark">
            {titles.map(title => (
                <Carousel.Item key={title.url}>
                    <img
                        className="d-block w-100 vh-100 p-5"
                        src={title.titleExtras?.poster}
                        alt={title.primarytitle}
                    />
                    <Carousel.Caption className="bg-dark bg-opacity-80 rounded p-3 text-white mt-5">
                        <h3>{title.primarytitle}</h3>
                        <p>{title.titleExtras?.plot}</p>
                    </Carousel.Caption>
                </Carousel.Item>
            ))}
        </Carousel>
    );
}
