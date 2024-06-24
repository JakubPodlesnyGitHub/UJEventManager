import { Container } from "react-bootstrap";
import Bar from "../bar/Bar";

export default function Layout(props) {
  return (
    <div className="grid-container">
      <header>
        <div>The Bookworm's Den</div>
      </header>
      <main>
        <Bar />
        <Container>{props}</Container>
      </main>
    </div>
  );
}
