import { IRouter } from "../../commons/modules";
import Home from "./Home";
import Login from "./Login";
import Product from "./Product";
export const ClientRoutes: IRouter[] = [
  {
    path: "/",
    name: "Trang chủ",
    exact: true,
    component: Home,
  },
  {
    path: "/product",
    name: "Trang sản phẩm",
    component: Product
  },
  {
    path: "/login",
    name: "Đăng nhập",
    component: Login,
    withoutLayout: true,
  },
];
