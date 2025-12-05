import { useEffect, useState } from "react";
import { getPersonImages } from "../api/persons";

export function usePersonImages(id) {
    const [images, setImages] = useState([]);

    useEffect(() => {
        if (!id) return;

        getPersonImages(id).then(imgs => {
            setImages(imgs);
        });

    }, [id]);

    return images;
}
