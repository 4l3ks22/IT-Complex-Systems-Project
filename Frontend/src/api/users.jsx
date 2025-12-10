const BASE_URL = "http://localhost:5000/api/users";

// Register a new user
export function registerUser(user) {
    return fetch(BASE_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user)
    })
        .then(res => res.ok ? res.json() : Promise.reject("Failed to register user"));
}

// Login user
export function loginUser(credentials) {
    return fetch(`${BASE_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(credentials)
    })
        .then(res => res.ok ? res.json() : Promise.reject("Invalid login"));
}