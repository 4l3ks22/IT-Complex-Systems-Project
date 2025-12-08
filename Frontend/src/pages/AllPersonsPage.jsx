
import React from "react";
import MainNavbar from "../components/layout/MainNavbar.jsx";
import PaginatedPersons from "../components/PaginatedPersons.jsx";

export default function AllPersonsPage() {
    return (
        <div>
            <MainNavbar/>
            <PaginatedPersons/>
        </div>
    );
}