import { useParams } from "react-router-dom";
import { useTitle } from "../hooks/useTitleId";
import StarRating from "../components/ui/StarRating.jsx";
import { useUserRatings } from "../hooks/useUserRatings";
import BookmarkButton from "../components/BookmarkButton.jsx";

export default function TitlePage() {
    const { id } = useParams();
    const title = useTitle(id);

    // const userId = Number(localStorage.getItem("userId"));
    // const [userRating, setUserRating] = useUserRatings(userId, id, title?.primarytitle);

    if (!title) return <p>Loading title...</p>;

    return (
        <div>
            <h2>{title.primarytitle}</h2>
            <p><strong>Year:</strong> {title.startyear}</p>
            <p><strong>Genres:</strong> {title.titleGenres.join(", ")}</p>
            {title.titleExtras?.poster && (
                <img src={title.titleExtras.poster} alt="poster" style={{ width: "250px", borderRadius: "8px" }} />
            )}
            <p className="mt-3">{title.titleExtras?.plot}</p>

            {/*<div style={{ marginTop: "20px" }}>*/}
            {/*    <p>Your Rating:</p>*/}
            {/*    <StarRating initialRating={userRating} onChange={setUserRating} />*/}
            {/*</div>*/}
            <BookmarkButton type="title" id={id} />
        </div>

    );
}