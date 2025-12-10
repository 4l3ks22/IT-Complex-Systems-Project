import PaginatedGenres from "../components/PaginatedGenres.jsx";
import React from "react";
import MainNavbar from "../components/layout/MainNavbar.jsx";

export default function AllGenresPage() {
    return (
        <div>
            <MainNavbar/>
            <PaginatedGenres/>
        </div>
    );
}