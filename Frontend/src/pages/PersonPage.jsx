import { useParams, Link } from "react-router-dom";
import { usePerson } from "../hooks/usePersonId";
import { usePersonImages } from "../hooks/usePersonImages";
import BookmarkButton from "../components/BookmarkButton.jsx";
export default function PersonPage() {
    const { id } = useParams();
    const person = usePerson(id);

    const images = usePersonImages(id);

    if (!person) return <p>Loading person...</p>;

    return (
        <div>
            <h2>{person.primaryname}</h2>

            <p><strong>Birth year:</strong> {person.birthyear}</p>
            <p><strong>Death year:</strong> {person.deathyear}</p>

            <p><strong>Professions:</strong> {person.professions.join(", ")}</p>

            <p><strong>Rating:</strong> {person.personRating}</p>


            {/* ---- Images from the TMDB, part 3-D.2 ----*/}
            <h3>Pictures</h3>
            <div style={{ display: "flex", gap: "10px", flexWrap: "wrap" }}>
                {images.map((img, i) => (
                    <img
                        key={i}
                        src={`https://image.tmdb.org/t/p/w200${img.file_path}`}
                        alt="profile"
                        style={{ borderRadius: "8px" }}
                    />
                ))}
            </div>

            <h3 className="mt-4">Known Titles</h3>
            <ul className="list-group">
                {person.titles.map(t => (
                    <li key={t.url} className="list-group-item">
                        <Link to={`/titles/${t.url.split("/").pop()}`}>
                            {t.title} – <i>{t.category}</i>
                        </Link>
                    </li>
                ))}
            </ul>
            <BookmarkButton type="person" id={id} />
        </div>
    );
}
