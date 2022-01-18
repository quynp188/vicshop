import React, { useState } from "react";
import { ChatTitle } from "../../../components/Client/Chat/ChatTitle";
import { ChatBody } from "../../../components/Client/Chat/ChatBody";
import { ChatFooter } from "../../../components/Client/Chat/ChatFooter";
import {
  Container,
  Wrapper,
  InputChexbox,
  StyledClearIcon,
  StyledLableIcon,
  StyledMessageIcon,
} from "./styles";
import { createStructuredSelector } from "reselect";
import { connect } from "react-redux";

const ChatBox = () => {
  const [value, setCheckboxMesage] = useState<Boolean>(false);
  return (
    <Container>
      <StyledLableIcon htmlFor="click">
        <InputChexbox
          type="checkbox"
          id="click"
          onClick={() => setCheckboxMesage(!value)}
        />
        <StyledMessageIcon />
        <StyledClearIcon />
      </StyledLableIcon>
      <Wrapper isChecked={value}>
        <ChatTitle />
        <ChatBody />
      </Wrapper>
    </Container>
  );
};
const mapStateToProps = createStructuredSelector({});
export default connect(mapStateToProps)(ChatBox);
