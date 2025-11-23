import { useState, useEffect } from "react";
import './App.css'
import ThemeButton from "./components/themeButton";

function App() {
    
    return (
        <div>
            <ThemeButton />
            <h1>What genre is on number 4?</h1>
            <p>{genre}</p>
        </div>
    );
    
}

export default App
