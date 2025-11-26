/*import React from "react";
import { useTitles } from "../hooks/useTitles";

export default function HomePage() {
    const titles = useTitles();
 

    return (
        <div>
            <h1>All Titles</h1>
            <ul>
                {titles.map(title => (
                    <li key={title.url}>
                        {title.primarytitle} - {title.startyear}
                    </li>
                ))}
            </ul>
        </div>
    );
}*/

import React from "react";
import { usePaginatedTitles } from "../hooks/usePaginatedTitles";
import { usePersons } from "../hooks/usePersons";


export default function HomePage() {
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



