import { useEffect, useState } from "react";
import { getTitleById } from "../api/titles";

export function useTitle(id) {
    const [data, setData] = useState(null);

    useEffect(() => {
        if (!id) return;

        getTitleById(id).then(result => {
            setData(result);
        });
    }, [id]);

    return data;
}