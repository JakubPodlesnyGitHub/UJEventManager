import { Container } from "react-bootstrap";
import Bar from "../bar/Bar";

export default function Layout(props) {
  return (
    <div className="grid-container">
      <header>
        <a href="/public"> SHOP</a>
      </header>
      <main>
        <Bar />
        <Container>{props}</Container>
      </main>
    </div>
  );
}
