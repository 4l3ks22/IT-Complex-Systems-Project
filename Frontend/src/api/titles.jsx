const BASE_URL = "http://localhost:5000/api/titles";

export function getAllTitles() {
    return fetch(BASE_URL)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

export function getTitleById(id) {
    return fetch(`${BASE_URL}/${id}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

//function to serach titles by name in a search bar
export function searchTitles(name) {
    return fetch(`${BASE_URL}/search?name=${encodeURIComponent(name)}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}