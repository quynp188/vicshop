import { IMessageProps } from "./module";
import styled from "styled-components";
import MessageIcon from "@material-ui/icons/Message";
import ClearIcon from "@material-ui/icons/Clear";
export const Wrapper = styled.div`
  position: fixed;
  right: 30px;
  max-width: 400px;
  background-color: #fff;
  box-shadow: 0px 15px 20px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
  opacity: 0;
  pointer-events: none;
  transition: all 0.6s cubic-bezier(0.68, -0.55, 0.265, 1.55);
  z-index: 9999;
  ${(props: IMessageProps) =>
    props.isChecked &&
    `
    opacity: 1;
    bottom: 85px;
    pointer-events: auto;
  `}
`;

export const Container = styled.div``;
export const StyledLableIcon = styled.label`
  position: fixed;
  right: 30px;
  bottom: 20px;
  width: 55px;
  height: 55px;
  background: -webkit-linear-gradient(left, #a445b2, #fa4299);
  text-align: center;
  line-height: 55px;
  border-radius: 50px;
  font-size: 30px;
  color: #fff;
  cursor: pointer;
  svg.MuiSvgIcon-root {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    transition: all 0.4s ease;
  }
  z-index: 9999;
`;
export const StyledMessageIcon = styled(MessageIcon)``;
export const StyledClearIcon = styled(ClearIcon)`
  opacity: 0;
  pointer-events: none;
`;

export const InputChexbox = styled.input`
  display: none;
  &:checked ~ ${StyledClearIcon} {
    opacity: 1;
    pointer-events: auto;
    transform: translate(-50%, -50%) rotate(180deg);
  }
  &:checked ~ ${StyledMessageIcon} {
    opacity: 0;
    pointer-events: none;
    transform: translate(-50%, -50%) rotate(180deg);
  }
`;
