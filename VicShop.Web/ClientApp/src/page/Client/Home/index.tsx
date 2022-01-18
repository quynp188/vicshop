import React, { useEffect } from "react";
import { connect, useDispatch } from "react-redux";
import Announcement from "../../../components/Client/Announcement";
import Categories from "../../../components/Client/Categories";
import Footer from "../../../components/Client/Footer";
import Navbar from "../../../components/Client/Navbar";
import Newsletter from "../../../components/Client/Newsletter";
import Products from "../../../components/Client/Products";
import Slider from "../../../components/Client/Slider";
import { makeSelectProductState } from "./selectors";
import { requestProductData } from "./action";
import { createStructuredSelector } from "reselect";
import { Iprops } from "./modules";
const Home = (props: Iprops) => {
  const { products } = props;
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(requestProductData());
  }, []);
  return (
    <div>
      <Announcement />
      <Navbar />
      <Slider />
      <Categories />
      {products && <Products products={products} />}
      <Newsletter />
      <Footer />
    </div>
  );
};
const mapStateToProps = createStructuredSelector({
  products: makeSelectProductState(),
});
export default connect(mapStateToProps)(Home);
