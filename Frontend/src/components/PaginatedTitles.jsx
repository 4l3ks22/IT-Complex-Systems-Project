import {usePaginatedTitles} from "../hooks/usePaginatedTitles.jsx";
import React from "react";

export default function PaginatedTitles() {
    const { titles, pageInfo, loading, setUrl } =
        usePaginatedTitles("http://localhost:5000/api/titles");
    
    if (loading) return <p>Loading titles...</p>;
    
    return (
        <div>
            <h1>All Titles</h1>
            <ul className="list-group mb-3">
                {titles.map(t => (
                    <li key={t.url} className="list-group-item">
                        <a href={`/titles/${t.url.split("/").pop()}`}>
                            {t.primarytitle} ({t.startyear})
                        </a>
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