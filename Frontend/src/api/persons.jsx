const BASE_URL = "http://localhost:5220/api/persons";

export function getPersonById(id) {
    return fetch(`${BASE_URL}/${id}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch person"));
}
