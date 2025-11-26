import { useEffect, useState } from 'react';
import { getAllPersons } from '../api/persons.jsx';

export function usePersons() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getAllPersons()
            .then(res => setData(res.items)) 
            .catch(err => console.error(err));
    }, []);

    return data;
}
