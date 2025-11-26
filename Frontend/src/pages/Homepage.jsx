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

export default function HomePage() {
    return (
        <p>
            <PaginatedTitles/>
        </p>
    );
}



