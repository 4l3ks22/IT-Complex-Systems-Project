const BASE_URL = "http://localhost:5000/api/persons";

export function getAllPersons() {
    return fetch(BASE_URL)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

export function getPersonById(id) {
    return fetch(`${BASE_URL}/${id}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

// adding search persons by name
export function searchPersons(name) {
    return fetch(`${BASE_URL}/search?name=${encodeURIComponent(name)}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to search persons"));
}