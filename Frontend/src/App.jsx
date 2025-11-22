import { useState, useEffect } from "react";
import './App.css'

function App() {
    const [genre, setGenre] = useState(null);

    useEffect(() => {
        fetch("http://localhost:5220/api/genres/4")
            .then(res => res.json())
            .then(data => setGenre(data.genreName))
            .catch(err => console.error("Fetch error:", err));
    }, []);

    return (
        <div>
            <h1>What genre is on number 4?</h1>
            <p>{genre}</p>
        </div>
    );
    
}

export default App
