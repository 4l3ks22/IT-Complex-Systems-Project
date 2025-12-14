import { useState, useEffect } from "react";
import { getUserRatings } from "../api/ratings";

export function useUserRatings(userId) {
    const [ratings, setRatings] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!userId || !token) {
            setLoading(false);
            return;
        }

        getUserRatings(userId, token)
            .then(data => setRatings(data))
            .catch(err => setError(err))
            .finally(() => setLoading(false));
    }, [userId]);

    return { ratings, loading, error };
}