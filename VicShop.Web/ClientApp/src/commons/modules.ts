export interface IRouter {
  path: string;
  name: string;
  exact?: boolean;
  component: any;
  withoutLayout?: boolean
}
export interface IResponseResult {
  status?: number;
  message?: string | any;
  data?: any;
}
