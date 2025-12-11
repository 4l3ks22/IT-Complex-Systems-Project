import { Routes, Route } from "react-router-dom";
import Container from "react-bootstrap/Container";
import MainNavbar from "./components/layout/MainNavbar.jsx";
import HomePage from "./pages/Homepage.jsx";
import TitlePage from "./pages/TitlePage.jsx";
import SearchResultsPage from "./pages/SearchResultsPage.jsx";
import RegisterPage from "./pages/RegisterPage.jsx";
import AllTitlesPage from "./pages/AllTitlesPage.jsx";
import PersonPage from "./pages/PersonPage.jsx";
import PersonSearchResultsPage from "./pages/PersonSearchResultsPage.jsx";
import AllPersonsPage from "./pages/AllPersonsPage.jsx";
import GenrePage from "./pages/GenrePage.jsx";
import AllGenresPage from "./pages/AllGenresPage.jsx";
import BookmarksPage from "./pages/BookmarksPage.jsx";

export default function App() {
    return (
        <>
            <MainNavbar />
            <Container className="mt-4">
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/titles/:id" element={<TitlePage />} />
                    <Route path="/search" element={<SearchResultsPage />} />
                    <Route path="/register" element={<RegisterPage />} />
                    <Route path="/titles" element={<AllTitlesPage />} />
                    <Route path="/persons/:id" element={<PersonPage />} />
                    <Route path="/search-person" element={<PersonSearchResultsPage />} />
                    <Route path="/persons" element={<AllPersonsPage />} />
                    <Route path="/genres/:id" element={<GenrePage />} />
                    <Route path="/genres" element={<AllGenresPage />} />
                    <Route path="/users/:id/bookmarks" element={<BookmarksPage />} />
                </Routes>
            </Container>
        </>
    );
}
