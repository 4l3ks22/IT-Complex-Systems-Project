import { useEffect, useState } from 'react';
import { getAllTitles } from '../api/titles';

export function useTitles() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getAllTitles()
            .then(res => setData(res.items)) 
            .catch(err => console.error(err));
    }, []);

    return data;
}
