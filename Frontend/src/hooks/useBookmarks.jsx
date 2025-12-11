import { getUserBookmarks } from "../api/users.jsx";
import { useEffect, useState } from "react";

export function useBookmarks(userId) {
    const [bookmarks, setBookmarks] = useState([]);
    const [loaded, setLoaded] = useState(false);
    const [error, setError] = useState(null);

    useEffect(() => {
        if (!userId) return;

        getUserBookmarks(userId)
            .then(data => {
                if (data && data.bookmarks) {
                    setBookmarks(data.bookmarks);
                } else {
                    setBookmarks([]);
                }
                setLoaded(true);
            })
            .catch(err => {
                setError(err.message || "Failed to fetch bookmarks");
                setLoaded(true);
            });
    }, [userId]);

    return { bookmarks, loaded, error };
}
 