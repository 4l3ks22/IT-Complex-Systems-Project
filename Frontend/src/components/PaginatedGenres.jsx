import {usePaginatedGenres} from "../hooks/usePaginatedGenres.jsx";
import React from "react";
import { Link } from "react-router-dom";

export default function PaginatedGenres() {
    const { genres, pageInfo, loading, setUrl } =
        usePaginatedGenres("http://localhost:5000/api/genres");

    if (loading) return <p>Loading genres...</p>;

    return (
        <div>
            <h1>Titles by Genres</h1>
            <ul className="list-group mb-3">
                {genres.map(g => (
                    <li key={g.url} className="list-group-item">
                        <Link to={`/genres/${g.url.split("/").pop()}`}>
                            {g.genreName}
                        </Link>
                    </li>
                ))}
            </ul>

            <div className="d-flex gap-2">
                <button
                    className="btn btn-secondary"
                    disabled={!pageInfo.prev}
                    onClick={() => setUrl(pageInfo.prev)}
                >
                    Previous
                </button>

                <button
                    className="btn btn-secondary"
                    disabled={!pageInfo.next}
                    onClick={() => setUrl(pageInfo.next)}
                >
                    Next
                </button>

            </div>
        </div>
    );
}