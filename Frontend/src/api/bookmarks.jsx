const BASE_URL = "http://localhost:5000/api/bookmarks";

export function getBookmarkByUserId(userId, token) {
    return fetch(`${BASE_URL}/${userId}`, {
        headers: {
            "Authorization": `Bearer ${token}`
        }
    }).then(res =>
        res.ok ? res.json() : Promise.reject("Failed to fetch bookmarks")
    );
}