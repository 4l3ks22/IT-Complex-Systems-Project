import { useEffect, useState } from "react";

export function useGenreTitles(genreId, initialPageUrl) {
    const [titles, setTitles] = useState([]);
    const [pageInfo, setPageInfo] = useState(null);
    const [url, setUrl] = useState(initialPageUrl);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        if (!url) return;

        setLoading(true);

        fetch(url)
            .then(res => res.json())
            .then(data => {
                setTitles(data.items);
                setPageInfo({
                    first: data.first,
                    prev: data.prev,
                    next: data.next,
                    last: data.last,
                    current: data.current,
                });
                setLoading(false);
            })
            .catch(err => {
                console.error("Genre titles fetch error:", err);
                setLoading(false);
            });

    }, [url]);

    return { titles, pageInfo, loading, setUrl };
}
