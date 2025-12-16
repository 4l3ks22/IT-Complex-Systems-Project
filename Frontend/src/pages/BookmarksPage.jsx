import React from "react";
import { useBookmarkId } from "../hooks/useBookmarkId.jsx";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";

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
            <h1>Your Bookmarks</h1>

            <Row>
                {data.items.map(bookmark => (
                    <Col key={bookmark.bookmarkId} md={6} lg={4} className="mb-3">
                        <div className="border p-3 rounded">
                            <p><b>Title ID:</b> {bookmark.tconst}</p>
                            <p><b>Saved on:</b> {new Date(bookmark.bookmarkTime).toLocaleString()}</p>
                        </div>
                    </Col>
                ))}
            </Row>
        </div>
    );
}