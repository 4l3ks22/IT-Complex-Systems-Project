import { Routes, Route } from "react-router-dom";
import HomePage from "./pages/Homepage.jsx";
import TitlePage from "./pages/TitlePage.jsx";
import './App.css';
import SearchResultsPage from "./pages/SearchResultsPage.jsx";
import RegisterPage from "./pages/RegisterPage.jsx";
import AllTitlesPage from "./pages/AllTitlesPage.jsx";
import PersonPage from "./pages/PersonPage.jsx";
import AllPersonsPage from "./pages/AllPersonsPage.jsx";
import GenrePage from "./pages/GenrePage.jsx";
import AllGenresPage from "./pages/AllGenresPage.jsx";
import RatingsPage from "./pages/RatingsPage.jsx"; // <- import RatingsPage
import MainNavbar from "./components/layout/MainNavbar.jsx";
import BookmarksPage from "./pages/BookmarksPage.jsx";

export default function App() {
    return (
        <>
            <MainNavbar />

            <div className="app-container">
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/titles/:id" element={<TitlePage />} />
                    <Route path="/search" element={<SearchResultsPage />} />

                    <Route path="/register" element={<RegisterPage />} />
                    <Route path="/titles" element={<AllTitlesPage />} />

                    {/* Routes for Persons search */}
                    <Route path="/persons/:id" element={<PersonPage />} />
                    <Route path="/persons" element={<AllPersonsPage />} />

                    <Route path="/genres/:id" element={<GenrePage />} />
                    <Route path="/genres" element={<AllGenresPage />} />
                    
                    <Route path="/bookmarks/:id" element={<BookmarksPage />} />

                    {/* Ratings page route */}
                    <Route path="/users/:userId/ratings" element={<RatingsPage />} />
                </Routes>
            </div>
        </>
    );
}