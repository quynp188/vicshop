import React from "react";
import { Iprops } from "./module";
import Product from "./Product";
import { Container } from "./styles";

const Products = (props: Iprops) => {
  const {products} = props;
  return (
    <Container>
      {products.map((item) => (
        <Product item={item} key={item.Id} />
      ))}
    </Container>
  );
};

export default Products;
