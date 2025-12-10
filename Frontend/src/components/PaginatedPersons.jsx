import {usePaginatedPersons} from "../hooks/usePaginatedPersons.jsx";
import React from "react";
import {Link} from "react-router-dom";

export default function PaginatedPersons() {
    const { persons, pageInfo, loading, setUrl } =
        usePaginatedPersons("http://localhost:5000/api/persons");

    if (loading) return <p>Loading actors...</p>;

    return (
        <div>
            <h1>All Actors</h1>
            <ul className="list-group mb-3">
                {persons.map(p => (
                    <li key={p.url} className="list-group-item">
                        <Link to={`/persons/${p.url.split("/").pop()}`}>
                            {p.primaryname} ({p.birthyear})
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