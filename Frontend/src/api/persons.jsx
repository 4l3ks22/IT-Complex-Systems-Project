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


// Implementing part 3-D.2  of the subproject3 to fetch for images for persons
const TMDB_KEY = "219f1fc61d6cd508abad7d15ffce53c4"; // cesar's key

export async function getPersonImages(nconst) {
    try {
        // implementing async function and await as in lectures
        const res1 = await fetch(
            //This http address will receive nconst from the internal_source database
            //From <Route path="/persons/:id" element={<PersonPage />} />
            //Since PersonPage uses import { usePerson } from "../hooks/usePersonId";
            `https://api.themoviedb.org/3/find/${nconst}?external_source=imdb_id&api_key=${TMDB_KEY}`
        );
        //receiving json data from the previous fetch of an actor from nconst
        const data1 = await res1.json();

        if (!data1.person_results || data1.person_results.length === 0)
            return [];
        //obtaining and storing the id
        const tmdbId = data1.person_results[0].id; // to get the id of the person from a nconst

        // 2. Fetch the images from TMDB
        const res2 = await fetch(
            `https://api.themoviedb.org/3/person/${tmdbId}/images?api_key=${TMDB_KEY}`
        );
        const data2 = await res2.json();

        return data2.profiles ?? [];
    }
    catch (err) {
        console.error("Failed loading TMDB images:", err);
        return [];
    }
}
