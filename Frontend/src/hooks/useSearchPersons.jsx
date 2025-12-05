import { useState, useEffect } from "react";
import { searchPersons } from "../api/persons.jsx";

export function useSearchPersons(name) {
    const [results, setResults] = useState([]);

    useEffect(() => {
        if (!name) return;
        
        searchPersons(name)
            .then(data => {
                setResults(Array.isArray(data) ? data : [data]);
                //setLoading(false);
            });
        
    }, [name]);

    return { results };
}
