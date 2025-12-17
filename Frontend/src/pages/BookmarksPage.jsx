import React from "react";
import { useBookmarkId } from "../hooks/useBookmarkId.jsx";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { Link } from 'react-router-dom'
export default function BookmarksPage() {
    const userIdStr = localStorage.getItem("userId");
    const userId = userIdStr ? parseInt(userIdStr, 10) : null;

    const { data, loading, error } = useBookmarkId(userId);

    if (!userId) return <p>Please log in to see your bookmarks.</p>;
    if (loading) return <p>Loading bookmarks...</p>;
    if (error) return <p>Error: {error}</p>;
    if (!data || data.items.length === 0)
        return <p>You have no bookmarks yet.</p>;

    return (
        <div>
            <h1 className="align-content-lg-start">Your Bookmarks</h1>
            <div className="card-group">
            <Row className=" justify-content-center">
                {data.items.map(bookmark => (
                    <Col key={bookmark.bookmarkId} md={6} lg={4} className="mb-3">
                        <div className="card border p-3 rounded">
                            <div className="card-body">

                            <h5 className="card-title">Tconst:<Link to={`/titles/${bookmark.tconst}`}>{bookmark.tconst}</Link></h5>

                            <h5 className="card-title">Nconst:<Link to={`/persons/${bookmark.nconst}`}>{bookmark.nconst}</Link></h5>
                            <p><b>Saved on:</b> {new Date(bookmark.bookmarkTime).toLocaleString()}</p>
                            </div>
                        </div>
                    </Col>
                ))}
            </Row>
            </div>
        </div>
    );
}