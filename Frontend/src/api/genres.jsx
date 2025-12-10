const BASE_URL = "http://localhost:5000/api/genres";

export function getAllGenres() {
    return fetch(BASE_URL)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

export function getGenreById(id) {
    return fetch(`${BASE_URL}/${id}`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch"));
}

//Adding the function to get titles by GenreId
export function getTitlesByGenre(id) {
    return fetch(`http://localhost:5000/api/genres/${id}/titles`)
        .then(res => res.ok ? res.json() : Promise.reject("Failed to load titles for genre"));
}
