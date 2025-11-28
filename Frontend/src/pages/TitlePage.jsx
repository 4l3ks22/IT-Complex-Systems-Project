import { useParams } from "react-router-dom";
import { useTitle } from "../hooks/useTitleId";

export default function TitlePage() {
    const { id } = useParams(); ////Importing component hook to hook in React Router provides access to dynamic URL parameters (such as /user/:id)
    const title = useTitle(id);

    if (!title) return <p>Loading title...</p>;

    return (
        <div>
            <h2>{title.primarytitle}</h2>

            <p><strong>Year:</strong> {title.startyear}</p>
            <p><strong>Genres:</strong> {title.titleGenres.join(", ")}</p>

            {title.titleExtras?.poster && (
                <img
                    src={title.titleExtras.poster}
                    alt="poster"
                    style={{ width: "250px", borderRadius: "8px" }}
                />
            )}

            <p className="mt-3">{title.titleExtras?.plot}</p>
        </div>
    );
}