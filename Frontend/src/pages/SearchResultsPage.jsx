import React from "react";
import { useSearchParams, Link } from "react-router-dom";
import { useSearchTitles } from "../hooks/useSearchTitles";
import { useSearchPersons } from "../hooks/useSearchPersons";

export default function SearchResultsPage() {
    const [params] = useSearchParams();
    const name = params.get("name");

    const { results: titles } = useSearchTitles(name);
    const { results: persons } = useSearchPersons(name);

    if (!titles || !persons) {
        return <p>Loading search results...</p>;
    }

    if (!titles.length && !persons.length) {
        return <p>No results found for "{name}"</p>;
    }

    return (
        <div>
            <h2>Search results for "{name}"</h2>

            {/* Movies / Series */}
            {titles.length > 0 && (
                <>
                    <h4 className="mt-4">Movies & Series</h4>
                    <ul className="list-group mb-4">
                        {titles.map(t => (
                            <li key={t.url} className="list-group-item">
                                <Link to={`/titles/${t.url.split("/").pop()}`}>
                                    {t.primarytitle} ({t.startyear})
                                </Link>
                            </li>
                        ))}
                    </ul>
                </>
            )}

            {/* Persons */}
            {persons.length > 0 && (
                <>
                    <h4 className="mt-4">Persons</h4>
                    <ul className="list-group">
                        {persons.map(p => (
                            <li key={p.url} className="list-group-item">
                                <Link to={`/persons/${p.url.split("/").pop()}`}>
                                    {p.primaryname} ({p.birthyear})
                                </Link>
                            </li>
                        ))}
                    </ul>
                </>
            )}
        </div>
    );
}