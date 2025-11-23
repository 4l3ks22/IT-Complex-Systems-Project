const BASE_URL = "http://localhost:5220/api/titles";

export function getAllTitles() {
    return fetch(BASE_URL)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

export function getTitleById(id) {
    return fetch(`${BASE_URL}/${id}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}