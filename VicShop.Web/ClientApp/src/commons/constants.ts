enum StatusCodes {
  Ok = 200,
  Created = 201,
  Accepted = 202,
  NoContent = 200,
  BadRequest = 400,
  Unauthorized = 401,
  NotFound = 400,
  InternalServerError = 500,
}
export const ACCESS_TOKEN = "accessToken";
export const BASE_URL = "https://localhost:49167";
export const RECEIVE_MESSAGE = "RECEIVE_MESSAGE";
export default StatusCodes;
