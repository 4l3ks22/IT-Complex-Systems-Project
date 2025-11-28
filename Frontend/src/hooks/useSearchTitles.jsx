import { useState, useEffect } from "react";
import { searchTitles } from "../api/titles";

export function useSearchTitles(name) {
    const [results, setResults] = useState([]);
    
    useEffect(() => {
        if (!name) return;

        searchTitles(name).then(result => {
            setResults(Array.isArray(result) ? result : [result]); // the results may be a single title or an array
        });
    }, [name]);

    return {results};


}