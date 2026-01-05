import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function SearchBar() {
    const [query, setQuery] = useState("");
    const navigate = useNavigate();

    function cleanQuery(q) {
        return q
            .trim()
            .replace(/\s+/g, " ")
            .replace(/[^\w\s]/g, "")
            .toLowerCase();
    }

    const submit = async (e) => {
        e.preventDefault();

        const cleaned = cleanQuery(query);
        if (!cleaned) return;

        const encoded = encodeURIComponent(cleaned);

        try {
            // searching for both titles and persons
            const [titleRes, personRes] = await Promise.all([
                fetch(`http://localhost:5000/api/titles/search?name=${encoded}`),
                fetch(`http://localhost:5000/api/persons/search?name=${encoded}`)
            ]);

            const titles = titleRes.ok ? await titleRes.json() : [];
            const persons = personRes.ok ? await personRes.json() : [];

            if (titles.length || persons.length) {
                navigate(`/search?name=${encoded}`);
            } else {
                navigate(`/search?name=${encoded}&empty=true`);
            }

        } catch (err) {
            console.error("Search failed:", err);
            navigate(`/search?name=${encoded}&error=true`);
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