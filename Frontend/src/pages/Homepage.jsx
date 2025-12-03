import React from "react";
import { useTitles } from "../hooks/useTitles";
import MainNavbar from "../components/layout/MainNavbar.jsx";
import GenresDropdown from "../components/GenresDropDown.jsx";
import NewestTitlesCarousel from "../components/ui/NewestTitlesCarousel.jsx";
import TopRatedTitlesGrid from "../components/ui/TopRatedTitlesGrid.jsx";
import TopRatedActorsGrid from "../components/ui/TopRatedActorsGrid.jsx";

export default function HomePage() {
    const allTitles = useTitles();

    // top 10 highest-rated titles for title grid
    const topRatedTitles = allTitles
        .filter(title => title.titleRating && typeof title.titleRating.averagerating === "number")
        .sort((a, b) => b.titleRating.averagerating - a.titleRating.averagerating)
        .slice(0, 10);

    // newest titles for carousel
    const newestTitles = allTitles
        .filter(title => title.startyear)
        .sort((a, b) => parseInt(b.startyear) - parseInt(a.startyear))
        .slice(0, 5);

    return (
        <div>
            <MainNavbar />
            
            <NewestTitlesCarousel titles={newestTitles} />
            
            <TopRatedTitlesGrid titles={topRatedTitles} />
            
            <TopRatedActorsGrid />
            <GenresDropdown />
        </div>
    );
}
