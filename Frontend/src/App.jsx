/*import HomePage from "./pages/Homepage.jsx";
import ThemeButton from "./components/ThemeButton.jsx";

function App() {
    return (
        <div>
            <ThemeButton/>
            <HomePage/>
        </div>
    );
}

export default App;*/

import { Routes, Route, Link } from "react-router-dom";
import HomePage from "./pages/Homepage.jsx";
import TitlePage from "./pages/TitlePage.jsx";

import ThemeButton from "./components/ThemeButton.jsx";

export default function App() {
    return (
        <div className="container mt-3">
            <ThemeButton />

            <nav className="mb-3">
                <Link to="/" className="btn btn-primary me-2">Home</Link>
            </nav>

            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/titles/:id" element={<TitlePage />} />

            </Routes>
        </div>
    );
}