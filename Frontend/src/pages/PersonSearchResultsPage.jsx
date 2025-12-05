import { useSearchParams, Link } from "react-router-dom";
import { useSearchPersons } from "../hooks/useSearchPersons";
import React from "react";

export default function PersonSearchResultsPage() {
    const [params] = useSearchParams();
    const name = params.get("name");

    const { results} = useSearchPersons(name);

    if (!results) return <p>Loading titles...</p>;

    return (
        <div>
            <h2>Results for "{name}"</h2>

            <ul className="list-group">
                {results.map(person => (
                    //the results are mapped and ready to be shown in a list according to every person url for matching query name
                    //then using Link React Router properties to link to PersonPage.jsx according to the abstracted id of the person
                    //<Link to={`/persons/${person.url.split("/").pop()}`}> will match the <Route path="/persons/:id" element={<PersonPage />} />
                    <li key={person.url} className="list-group-item">
                        <Link to={`/persons/${person.url.split("/").pop()}`}>
                            {person.primaryname} ({person.birthyear})
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
}
