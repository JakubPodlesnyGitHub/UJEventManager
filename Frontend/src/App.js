import Basket from "./Basket";

import ProductsView from "./ProductsView";
import { Container } from "react-bootstrap";

function App() {
  return (
    <div className="grid-container">
      <header>
        <a href="/"> SHOP</a>
      </header>
      <main>
        <Container>
          <Basket />
          <ProductsView />
        </Container>
      </main>
      <footer>Academic</footer>
    </div>
  );
}

export default App;
