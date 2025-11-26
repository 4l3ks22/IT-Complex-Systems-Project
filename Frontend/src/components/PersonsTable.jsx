import {usePersons} from "../hooks/usePersons";

export default function PersonsTable() {
    const persons = usePersons();
    return (
        <table>
            <thead>
            <tr>
                {persons.map(p => (
                    <li key = {p.url}>
                        {p.primaryname}
                    </li>
                    ))}
            </tr>
            </thead>
        </table>
    )
}