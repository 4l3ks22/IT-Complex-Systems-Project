const BASE_URL = "http://localhost:5000/api/episodes";

export function getAllEpisodes() {
    return fetch(BASE_URL)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch episodes"));
}

export function getEpisodeById(id) {
    return fetch(`${BASE_URL}/${id}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch episode"));
}
