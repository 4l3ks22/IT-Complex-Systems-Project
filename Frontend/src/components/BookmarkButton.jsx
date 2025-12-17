
import { addTitleBookmark, addPersonBookmark } from "../api/bookmarks";

export default function BookmarkButton({ type, id }) {
    const userId = localStorage.getItem("userId");
    const token = localStorage.getItem("token");

    if (!userId || !token) return null;

    const handleClick = async () => {
        try {
            if (type === "title") {
                await addTitleBookmark(userId, id, token);
                alert("Title bookmarked!");
            }

            if (type === "person") {
                await addPersonBookmark(userId, id, token);
                alert("Person bookmarked!");
            }
        } catch (err) {
            console.error(err);
            alert("Bookmark failed");
        }
    };

    return (
        <button className="btn btn-outline-warning mt-3" onClick={handleClick}>
            ⭐ Bookmark
        </button>
    );
}
