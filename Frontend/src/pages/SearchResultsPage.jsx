import React from "react";
import { useSearchParams, Link } from "react-router-dom";
import { useSearchTitles } from "../hooks/useSearchTitles";

export default function SearchResultsPage() {
    const [params] = useSearchParams(); //Importing component hook to read an URL's query string

    const name = params.get("name"); //params extract the title query name
    
    const { results } = useSearchTitles(name); // useSearchTitles receives the name and fetches for an array of titles results
    
    if (!results) return <p>Loading titles...</p>;

    // An array of results to show list and links (React Router) to TitlePage <Route path="/titles/:id" element={<TitlePage />} />
    return (
        <div>
            <h2>Search results for "{name}"</h2>

            <ul className="list-group">
                {results.map(r => (
                    //the results are mapped and ready to be shown in a list according to every title url for matching query name
                    //then using Link React Router properties to link to TitlePage.jsx according to the abstracted id of the title
                    //<Link to={`/titles/${r.url.split("/").pop()}`}> will match the <Route path="/titles/:id" element={<TitlePage />} />
                    <li key={r.url} className="list-group-item">
                        <Link to={`/titles/${r.url.split("/").pop()}`}>
                            {r.primarytitle} ({r.startyear})
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
}