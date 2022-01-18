import { BASE_URL, RECEIVE_MESSAGE } from "./constants";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
export const sentMessageToRoom = async (
  name: string,
  phone: string,
  group: string,
  message: string
) => {
  try {
    const connection = new HubConnectionBuilder()
      .withUrl(`${BASE_URL}/chat`)
      .configureLogging(LogLevel.Information)
      .build();
    connection.on(RECEIVE_MESSAGE, (name, resmessage) => {
      return {
        name,
        message,
      };
    });
    await connection.start();
    await connection.invoke("SendMesssageToGroup", {
      name,
      group,
      phone,
      message,
    });
  } catch (error) {
    console.log(error);
  }
};
