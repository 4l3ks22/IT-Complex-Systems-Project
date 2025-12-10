import { useEffect, useState } from "react";
import { getGenreById } from "../api/genres";

export function useGenre(id) {
    const [data, setData] = useState(null);

    useEffect(() => {
        if (!id) return;

        getGenreById(id).then(result => {
            setData(result);
        });
    }, [id]);

    return data;
}