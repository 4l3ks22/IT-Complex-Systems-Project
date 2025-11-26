import { useEffect, useState } from 'react';
import { getAllGenres } from '../api/genres.jsx';

export function useGenres() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getAllGenres()
            .then(res => setData(res.items)) 
            .catch(err => console.error(err));
    }, []);

    return data;
}
