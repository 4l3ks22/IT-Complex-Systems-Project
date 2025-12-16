import { useState, useEffect } from "react";
import { getBookmarkByUserId } from "../api/bookmarks.jsx";

export function useBookmarkId(userId) {
    const [data, setData] = useState(null); // ← NOT []
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const token = localStorage.getItem("token");

        if (!userId || !token) {
            setLoading(false);
            return;
        }

        getBookmarkByUserId(userId, token)
            .then(result => setData(result)) // ← whole response
            .catch(err => setError(err))
            .finally(() => setLoading(false));

    }, [userId]);

    return { data, loading, error };
}