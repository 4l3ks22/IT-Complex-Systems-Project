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
import './App.css'
//import PersonsTable from "./components/PersonsTable.jsx";
import SearchResultsPage from "./pages/SearchResultsPage.jsx";
import RegisterPage from "./pages/RegisterPage.jsx";
import AllTitlesPage from "./pages/AllTitlesPage.jsx";
import PersonPage from "./pages/PersonPage.jsx";
import PersonSearchResultsPage from "./pages/PersonSearchResultsPage.jsx";

import AllPersonsPage from "./pages/AllPersonsPage.jsx";

export default function App() {
    return (
        <div className="container-mt-3">
           
            
            <nav className="mb-3">
                <Link to="/" className="btn btn-primary me-2">Home</Link>
            </nav>

            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/titles/:id" element={<TitlePage />} />
                <Route path="/search" element={<SearchResultsPage />} />
                
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/titles" element={<AllTitlesPage/>} />
                {/* Routes for Persons search */}
                <Route path="/persons/:id" element={<PersonPage />} />
                <Route path="/search-person" element={<PersonSearchResultsPage />} />

                <Route path="/persons" element={<AllPersonsPage/>} />
            </Routes>
            
        </div>
    );
}