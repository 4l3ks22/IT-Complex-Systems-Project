import { useParams, Link } from "react-router-dom";

import { useEffect, useState } from "react";
import { usePerson } from "../hooks/usePersonId";

export default function PersonPage() {
    const { id } = useParams();
    const person = usePerson(id);

    if (!person) return <p>Loading person...</p>;

    return (
        <div>
            <h2>{person.primaryname}</h2>

            <p><strong>Birth year:</strong> {person.birthyear}</p>
            <p><strong>Death year:</strong> {person.deathyear}</p>

            <p><strong>Professions:</strong> {person.professions.join(", ")}</p>

            <p><strong>Rating:</strong> {person.personRating}</p>

            <h3 className="mt-4">Known Titles</h3>
            <ul className="list-group">
                {person.titles.map(t => (
                    <li key={t.url} className="list-group-item">
                        <Link to={`/titles/${t.url.split("/").pop()}`}>
                            {t.title} – <i>{t.category}</i>
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
}
