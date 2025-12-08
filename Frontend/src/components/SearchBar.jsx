/*import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function SearchBar() {
    const [query, setQuery] = useState(""); //with useState and query parameter to store the 
                                                            // query from the user, starting with an empty space or string "", updating it with setQuery
    const navigate = useNavigate();

    const submit = (e) => { //This function handles what happens when the user submits the query name
        e.preventDefault(); //this is needed because the browser refreshes immediately  the page (browser’s default behavior) and the react state gets lost
        if (!query.trim()) return; // preventing the search not to fail and continue to show nothing in case a blank query
                                   // additionally, trimming empty spaces that cause a mistaken query

        navigate(`/search?name=${encodeURIComponent(query)}`); //tell React Router to change the URL
                                                              //encodeURIComponent method is needed in case of queries with spaces 
                                                             // or especial characters, so the url gets complete
    };

    return (
        // form allows to submit the query event to users by pressing Enter or clicks the button search below
        // the button Search triggers the submission event or Enter too
        <form className="d-flex mb-3" onSubmit={submit}> 
            <input
                className="form-control me-2"
                type="search"
                placeholder="Search for a movie or series..."
                value={query}
                // event e getting the value typed by the user, and setQuery updates that value initially empty string
                onChange={(e) => setQuery(e.target.value)}
            />
            <button className="btn btn-primary">Search</button>
        </form>
    );
}*/

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

