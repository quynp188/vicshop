import { IRouter } from "../../commons/modules";
import Home from "./Home";
import UserList from "./User/UserList";
import UserDetail from "./User/UserDetail";
import CreateUser from "./User/CreateUser";
import Login from "./Login";
export const AdminRoutes: IRouter[] = [
  {
    path: "/admin",
    name: "Trang chủ",
    exact: true,
    component: Home,
  },
  {
    path: "/admin/users",
    name: "Trang tài khoản",
    component: UserList,
  },
  {
    path: "/admin/user/:id",
    name: "Thông tin tài khoản",
    component: UserDetail,
  },
  {
    path: "/admin/create-user",
    name: "Thêm mới tài khoản",
    component: CreateUser,
  },
  {
    path: "/admin/login",
    name: "Đăng nhập",
    component: Login,
    withoutLayout: true,
  },
];
