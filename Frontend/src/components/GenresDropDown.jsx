import { useGenres } from "../hooks/useGenres";

export default function GenresDropdown() {
    const genres = useGenres();

    return (
        <select>
            {genres.map(g => (
                <option key={g.url} value={g.url}>
                    {g.genreName}
                </option>
            ))}
        </select>
    );
}
