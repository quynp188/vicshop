import React from "react";

import { ChatButton, FieldGroup, SentButton } from "./styles";
type Iprops = {
  disableStartButton: boolean;
  validMessage: boolean;
  displaySentButton: boolean;
  onHandleStartChat: () => void;
};
export const ChatFooter = (props: Iprops) => {
  return (
    <FieldGroup>
      <ChatButton
        onClick={props.onHandleStartChat}
        disabled={props.disableStartButton}
        type="button"
        display={!props.displaySentButton}
      >
        Start chat
      </ChatButton>
      <SentButton
        disabled={!props.validMessage}
        display={props.displaySentButton}
        type="submit"        
      >
        Sent Message
      </SentButton>
    </FieldGroup>
  );
};
