const BASE_URL = "http://localhost:5000/api/ratings";

export function getUserRatings(userId) {
    const token = localStorage.getItem("token");
    return fetch(`${BASE_URL}/${userId}`, {
        headers: { Authorization: `Bearer ${token}` }
    })
        .then(res => res.ok ? res.json() : Promise.reject("Failed to fetch user ratings"));
}

export function submitRating(dto) {
    const token = localStorage.getItem("token");
    if (!token) return Promise.reject("User not logged in");

    return fetch(`${BASE_URL}/rate`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify({
            UserId: dto.userId,
            Tconst: dto.tconst,
            Rating: dto.rating
        })
    })
        .then(res => res.ok ? res.json() : res.text().then(text => Promise.reject(text || "Failed to submit rating")));
}