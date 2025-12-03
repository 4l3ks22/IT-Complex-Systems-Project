import PaginatedTitles from "../components/PaginatedTitles.jsx";
import React from "react";
import MainNavbar from "../components/layout/MainNavbar.jsx";

export default function AllTitlesPage() {
    return (
        <div>
            <MainNavbar/>
            <PaginatedTitles/>
        </div>
    );
}