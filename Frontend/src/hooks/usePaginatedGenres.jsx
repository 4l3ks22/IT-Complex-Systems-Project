import { useEffect, useState } from "react";

export function usePaginatedGenres(initialUrl) {
    const [genres, setGenres] = useState([]);
    const [pageInfo, setPageInfo] = useState(null);
    const [url, setUrl] = useState(initialUrl);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        if (!url) return;

        setLoading(true);

        fetch(url)
            .then(res => res.json())
            .then(data => {
                setGenres(data.items);
                setPageInfo({
                    first: data.first,
                    prev: data.prev,
                    next: data.next,
                    last: data.last,
                    current: data.current
                });
                setLoading(false);
            })
            .catch(err => {
                console.error("Pagination fetch error:", err);
                setLoading(false);
            });
    }, [url]);

    return { genres, pageInfo, loading, setUrl };
}
