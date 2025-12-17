
import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function SearchBar() {
    const [query, setQuery] = useState("");
    const navigate = useNavigate();

   // Adding a cleaning function to optimize the search to avoid several issues to the user 
    function cleanQuery(q) {
        return q
            .trim()                     // remove spaces at start/end
            .replace(/\s+/g, " ")       // collapse multiple spaces
            .replace(/[^\w\s]/g, "")    // remove symbols such as !@#$%^&*()[]{};:'",.?
            .toLowerCase();             // convert to lowercase to avoid case problems
    }

    //using the cleaning function before the query is sent for request to backend
    const submit = async (e) => {
        e.preventDefault();

        let cleaned = cleanQuery(query); // adding a local variable to store the clean query

        //if (!query.trim()) return;
        if (!cleaned) return;

        //const encoded = encodeURIComponent(query);
        const encoded = encodeURIComponent(cleaned);

        try {
            // Trying the fetch of title search first
            const titleRes = await fetch(
                `http://localhost:5000/api/titles/search?name=${encoded}`
            );

            if (titleRes.ok) {
                const titleData = await titleRes.json();

                if (Array.isArray(titleData) && titleData.length > 0) {
                    navigate(`/search?name=${encoded}`);
                    return;
                }
            }

            // Then, trying the fetch of persons search if titles were not found
            const personRes = await fetch(
                `http://localhost:5000/api/persons/search?name=${encoded}`
            );

            if (personRes.ok) {
                const personData = await personRes.json();

                if (Array.isArray(personData) && personData.length > 0) {
                    navigate(`/search-person?name=${encoded}`);
                    return;
                }
            }

            // If nothing found is possible to show a "no results" page in the browser search
            navigate(`/search-not-found?name=${encoded}`);

        } catch (err) {
            console.error("Search failed:", err);
            navigate(`/search-not-found?name=${encoded}`);
        }
    };

    return (
        <form className="d-flex mb-3" onSubmit={submit}>
            <input
                className="form-control me-2"
                type="search"
                placeholder="Search for movies, series or actors..."
                value={query}
                onChange={(e) => setQuery(e.target.value)}
            />
            <button className="btn btn-primary">Search</button>
        </form>
    );
}

