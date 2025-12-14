import { useState } from "react";

export default function StarRating({ initialRating = null, maxStars = 10, onChange }) {
    const [rating, setRating] = useState(initialRating);
    const [hover, setHover] = useState(null);

    const handleClick = (value) => {
        const newRating = rating === value ? null : value; // toggle off if same star
        setRating(newRating);
        if (onChange) onChange(newRating);
    };

    return (
        <div style={{ display: "flex", alignItems: "center" }}>
            {[...Array(maxStars)].map((_, index) => {
                const starValue = index + 1;
                const isFilled = hover ? starValue <= hover : starValue <= (rating || 0);

                return (
                    <span
                        key={index}
                        onClick={() => handleClick(starValue)}
                        onMouseEnter={() => setHover(starValue)}
                        onMouseLeave={() => setHover(null)}
                        style={{
                            cursor: "pointer",
                            color: isFilled ? "gold" : "lightgray",
                            fontSize: "24px",
                            marginRight: "4px"
                        }}
                    >
                        ★
                    </span>
                );
            })}
            {rating && (
                <button onClick={() => handleClick(rating)} style={{ marginLeft: "10px" }}>
                    Clear
                </button>
            )}
        </div>
    );
}