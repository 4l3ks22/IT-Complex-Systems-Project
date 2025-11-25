import "./Navbar.css"
export function Navbar() {
    return (
        <nav className="navbar">
            <div className="navbar-logo">MyApp</div>
            <div className="navbar-links">
                <button>Home</button>
                <button>Movies</button>
                <button>Series</button>
                <button>Watchlist</button>
            </div>
            <div className="navbar-auth">
                <button className="signin-btn">Sign in</button>
            </div>
        </nav>
    );
}