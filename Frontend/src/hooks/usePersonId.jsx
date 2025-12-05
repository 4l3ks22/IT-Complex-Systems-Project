import { useEffect, useState } from "react";
import { getPersonById } from "../api/persons";

export function usePerson(id) {

    const [person, setPerson] = useState(null);

    useEffect(() => {
        if (!id) return;
        getPersonById(id).then(setPerson);
    }, [id]);



    return person;
}