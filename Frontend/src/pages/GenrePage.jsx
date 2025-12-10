import { useParams } from "react-router-dom";
import { useGenreTitles } from "../hooks/useGenreTitles";
import MainNavbar from "../components/layout/MainNavbar";

export default function GenrePage() {
    const { id } = useParams();

    const initialUrl = `http://localhost:5000/api/genres/${id}/titles`;

    const { titles, pageInfo, loading, setUrl } =
        useGenreTitles(id, initialUrl);

    if (loading) return <p>Loading titles...</p>;

    return (
        <div>
            <MainNavbar />

            <h2 className="mt-3">Titles in Genre #{id}</h2>

            <ul className="list-group mb-3">
                {titles.map(t => (
                    <li key={t.url} className="list-group-item">
                        <a href={`/titles/${t.url.split("/").pop()}`}>
                            {t.primarytitle} ({t.startyear})
                        </a>
                    </li>
                ))}
            </ul>

            {/* Pagination UI */}
            <div className="d-flex gap-2 mb-3">
                <button
                    className="btn btn-secondary"
                    onClick={() => setUrl(pageInfo.first)}
                    disabled={!pageInfo.first}
                >
                    First
                </button>

                <button
                    className="btn btn-secondary"
                    onClick={() => setUrl(pageInfo.prev)}
                    disabled={!pageInfo.prev}
                >
                    Prev
                </button>

                <button
                    className="btn btn-secondary"
                    onClick={() => setUrl(pageInfo.next)}
                    disabled={!pageInfo.next}
                >
                    Next
                </button>

                <button
                    className="btn btn-secondary"
                    onClick={() => setUrl(pageInfo.last)}
                    disabled={!pageInfo.last}
                >
                    Last
                </button>
            </div>
        </div>
    );
}
