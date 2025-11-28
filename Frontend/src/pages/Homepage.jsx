/*import React from "react";
import { useTitles } from "../hooks/useTitles";

export default function HomePage() {
    const titles = useTitles();
 

    return (
        <div>
            <h1>All Titles</h1>
            <ul>
                {titles.map(title => (
                    <li key={title.url}>
                        {title.primarytitle} - {title.startyear}
                    </li>
                ))}
            </ul>
        </div>
    );
}*/

import React from "react";
import { usePaginatedTitles } from "../hooks/usePaginatedTitles";
import { usePersons } from "../hooks/usePersons";
import PaginatedTitles from "../components/PaginatedTitles";
import Navbar from "../components/Navbar.jsx";
import ThemeButton from "../components/ThemeButton.jsx";
import GenresDropdown from "../components/GenresDropDown.jsx";
import SearchBar from "../components/SearchBar";

export default function HomePage() {
    return (
        <div>
            <Navbar />
            <ThemeButton />
            <GenresDropdown />
            <SearchBar />
            <PaginatedTitles/>
        </div>
    );
}



