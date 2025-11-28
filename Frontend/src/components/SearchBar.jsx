import { useState } from "react";
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
}
