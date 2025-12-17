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

export function addTitleBookmark(userId, tconst, token) {
    return fetch(BASE_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify({
            userId: userId.toString(),
            tconst
        })
    }).then(res =>
        res.ok ? res.json() : Promise.reject("Failed to add title bookmark")
    );
}

export function addPersonBookmark(userId, nconst, token) {
    return fetch(BASE_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify({
            userId: userId.toString(),
            nconst
        })
    }).then(res =>
        res.ok ? res.json() : Promise.reject("Failed to add person bookmark")
    );
}
export function deleteBookmark(bookmarkId, token) {
    return fetch(`${BASE_URL}/${bookmarkId}`, {
        method: "DELETE",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    }).then(res =>
        res.ok ? true : Promise.reject("Failed to delete bookmark")
    );
}
