import { useUserRatings } from "../hooks/useUserRatings";

export default function RatingsPage() {
    const userIdStr = localStorage.getItem("userId");
    const userId = userIdStr ? parseInt(userIdStr, 10) : null;

    const { ratings, loading, error } = useUserRatings(userId);

    if (!userId) return <p>Please log in to see your ratings.</p>;
    if (loading) return <p>Loading ratings...</p>;
    if (error) return <p>Error: {error}</p>;
    if (!ratings || ratings.length === 0) return <p>You have not rated any titles yet.</p>;

    return (
        <div className="ratings-page" style={{ padding: "20px", maxWidth: "600px", margin: "0 auto" }}>
            <h2 style={{ marginBottom: "20px" }}>My Ratings</h2>
            <ul style={{ listStyle: "none", padding: 0 }}>
                {ratings.map((r, index) => (
                    <li key={index} style={{
                        marginBottom: "15px",
                        padding: "10px",
                        border: "1px solid #ddd",
                        borderRadius: "8px",
                        backgroundColor: "#f9f9f9",
                        display: "flex",
                        justifyContent: "space-between"
                    }}>
                        <strong>{r.titleName}</strong>
                        <span>{r.rating} / 10</span>
                    </li>
                ))}
            </ul>
        </div>
    );
}