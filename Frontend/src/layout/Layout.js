import { Container } from "react-bootstrap";
import Bar from "../bar/Bar";

export default function Layout({ children }) {
    return (
        <div className="grid-container">
            <header>
                <div>The Bookworm's Den</div>
            </header>
            <main>
                <Bar />
                <Container>{children}</Container>
            </main>
        </div>
    );
}
