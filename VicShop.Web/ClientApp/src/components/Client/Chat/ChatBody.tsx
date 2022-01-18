import React, { useState } from "react";
import { ChatFooter } from "./ChatFooter";
import { ChatTitle } from "./ChatTitle";
import { IMessageBoxProps } from "./module";
import { sentMessageToRoom } from "../../../commons/signalRService";
import {
  ChatBox,
  DescText,
  ChatForm,
  FieldGroup,
  ChatButton,
  FieldGroupArea,
  FieldTextArea,
  SelectGroup,
  OptionGroup,
  FieldInput,
} from "./styles";

export const ChatBody = () => {
  const [yourName, setYourName] = useState<string>("");
  const [yourPhone, setYourPhone] = useState<string>("");
  const [yourGroup, setYourGroup] = useState<string>("");
  const [yourMessage, setYourMessage] = useState<string>("");
  const [isShowMessageBox, setShowMessageBox] = useState<boolean>(false);
  const isEnableStartChatBox = Boolean(yourName && yourPhone && yourGroup);
  const validMessage = Boolean(
    yourName && yourPhone && yourGroup && yourMessage
  );
  const onHandleStartChat = () => {
    setShowMessageBox(!isShowMessageBox);
  };
  const onHandleSentMessage = (e: React.SyntheticEvent<EventTarget>) => {
    e.preventDefault();
    sentMessageToRoom(yourName, yourPhone, yourGroup, yourMessage);
  };
  return (
    <ChatBox>
      <DescText>
        Please fill out the form to start chatting with next available agent.
      </DescText>
      <ChatForm onSubmit={onHandleSentMessage}>
        <FieldGroup>
          <FieldInput
            name="yourName"
            value={yourName}
            onChange={(e) => setYourName(e.target.value)}
            placeholder="Your name"
            required
          />
        </FieldGroup>
        <FieldGroup>
          <FieldInput
            name="yourPhone"
            value={yourPhone}
            onChange={(e) => setYourPhone(e.target.value)}
            placeholder="Your phone"
            required
          />
        </FieldGroup>
        <FieldGroup>
          <SelectGroup
            name="yourGroup"
            required
            value={yourGroup}
            onChange={(e) => setYourGroup(e.target.value)}
          >
            <OptionGroup value="">Chose support group</OptionGroup>
            <OptionGroup value="IT">Technical</OptionGroup>
            <OptionGroup value="Sale">Sale</OptionGroup>
          </SelectGroup>
        </FieldGroup>
        <FieldGroupArea>
          <FieldTextArea
            isShowMessageBox={isShowMessageBox}
            name="yourMessage"
            rows={10}
            cols={30}
            value={yourMessage}
            onChange={(e) => setYourMessage(e.target.value)}
            placeholder="Your messasage"
          />
        </FieldGroupArea>
        <ChatFooter
          onHandleStartChat={onHandleStartChat}
          disableStartButton={!isEnableStartChatBox}
          validMessage={validMessage}
          displaySentButton={isShowMessageBox}
        />
      </ChatForm>
    </ChatBox>
  );
};
