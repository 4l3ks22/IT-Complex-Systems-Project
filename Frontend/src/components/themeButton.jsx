import { Moon, Sun } from "lucide-react";
import { useTheme } from "../hooks/useTheme";

export default function themeToggle() {
    const { theme, toggleTheme } = useTheme();

    return (
        <button
            onClick={toggleTheme}
            style={{
                background: "none",
                border: "none",
                cursor: "pointer",
                padding: "8px"
            }}
        >
            {theme === "light" ? (
                <Moon size={26} />
            ) : (
                <Sun size={26} />
            )}
        </button>
    );
}