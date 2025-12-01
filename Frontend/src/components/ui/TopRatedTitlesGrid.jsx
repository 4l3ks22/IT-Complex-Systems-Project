export default function TopRatedTitlesGrid({ titles }) {
    if (!titles || titles.length === 0) return null;

    return (
        <div className="grid-container">
            {titles.map(title => (
                <div key={title.url} className="grid-item">
                    <img
                        src={title.titleExtras?.poster}
                        alt={title.primarytitle}
                    />
                    <h4>{title.primarytitle}</h4>
                    <p>Rating: {title.titleRating?.averagerating}</p>
                    <p>{title.startyear}</p>
                </div>
            ))}
        </div>
    );
}
