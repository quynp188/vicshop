import React from "react";
import {
  Language,
  NotificationsNone,
  Settings,
  ExitToApp,
} from "@material-ui/icons";
import {
  Container,
  AdminLogo,
  TopLeft,
  TopRight,
  Wrapper,
  TopbarIconContainer,
  TopIconBage,
  TopAvatar,
  UserInfoContainer,
} from "./styles";
import { Avatar } from "@material-ui/core";
import { Iprops } from "./module";

export default function Topbar({ onHandleLogout, fullName }: Iprops) {
  return (
    <Container>
      <Wrapper>
        <TopLeft>
          <AdminLogo>MS ADMIN</AdminLogo>
        </TopLeft>
        <TopRight>
          <TopbarIconContainer>
            <NotificationsNone />
            <TopIconBage>2</TopIconBage>
          </TopbarIconContainer>
          <TopbarIconContainer>
            <Language />
            <TopIconBage>2</TopIconBage>
          </TopbarIconContainer>
          <TopbarIconContainer>
            <Settings />
          </TopbarIconContainer>
          <UserInfoContainer>
            <TopAvatar src="https://pdp.edu.vn/wp-content/uploads/2021/05/hinh-anh-avatar-nam-1.jpg" />
            {fullName}
          </UserInfoContainer>
          <TopbarIconContainer onClick={onHandleLogout}>
            <ExitToApp />
          </TopbarIconContainer>
        </TopRight>
      </Wrapper>
    </Container>
  );
}
