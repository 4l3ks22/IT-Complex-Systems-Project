import { useParams, Link } from "react-router-dom";
import { useBookmarks } from "../hooks/useBookmarks";

export default function BookmarksPage() {
    const { id: userId } = useParams();
    const { bookmarks, loaded, error } = useBookmarks(userId);

    return (
        <div className="mt-4">
            <h2 className="mb-4">Your Bookmarks</h2>
            <Link to="/" className="btn btn-secondary mb-3">← Back to Home</Link>

            {!loaded && <p>Loading...</p>}
            {error && <p className="text-danger">{error}</p>}
            {loaded && bookmarks.length === 0 && !error && <p>You don't have any bookmarks yet.</p>}

            <div className="row">
                {bookmarks.map(b => (
                    <div className="col-md-3 mb-3" key={b.bookmarkId}>
                        <div className="card h-100">
                            <div className="card-body">
                                <h5 className="card-title">{b.title || b.personName}</h5>
                                <p className="card-text text-muted">{b.tconst || b.nconst}</p>
                                {b.tconst && <Link className="btn btn-primary" to={`/titles/${b.tconst}`}>View Title</Link>}
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}
