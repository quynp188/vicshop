import { Left } from "./../Footer/styles";
import styled from "styled-components";
import { IMessageBoxProps, IButtonProps } from "./module";
export const HeadText = styled.div`
  line-height: 60px;
  color: #fff;
  border-radius: 10px 10px 0 0;
  padding: 0 20px;
  font-size: 20px;
  font-weight: 500;
  background: -webkit-linear-gradient(left, #a445b2, #fa4299);
`;
export const ChatBox = styled.div`
  padding: 20px;
  width: 100%;
`;
export const DescText = styled.div`
  color: #515365;
  text-align: center;
  line-height: 25px;
  font-size: 17px;
  font-weight: 500;
`;
export const ChatForm = styled.form`
  padding: 10px 15px;
  margin: 20px 0px;
  border-radius: 10px;
  border: 1px solid lightgray;
`;
export const FieldGroup = styled.div`
  height: 50px;
  width: 100%;
  margin-top: 20px;
  &:last-child {
    margin-bottom: 15px;
  }
`;
export const FieldGroupArea = styled.div`
  margin-top: 20px;
  width: 100%;
  height: 100%;
`;
export const FieldInput = styled.input`
  width: 100%;
  height: 100%;
  padding-left: 20px;
  border: 1px solid lightgray;
  outline: none;
  border-radius: 10px;
  font-size: 16px;
  transition: all 0.3s ease;
  &:focus {
    border-color: #fc83bb;
  }
  &::placeholder {
    color: silver;
    transition: all 0.3s ease;
  }
  &:focus::placeholder {
    color: lightgray;
  }
`;
export const FieldTextArea = styled.textarea`
  width: 100%;
  height: 100%;
  padding-left: 20px;
  border: 1px solid lightgray;
  outline: none;
  border-radius: 10px;
  font-size: 16px;
  resize: none;
  padding: 15px 20px;
  transition: all 0.3s ease;
  display: none;

  ${(props: IMessageBoxProps) =>
    props.isShowMessageBox &&
    `
    display: block;
  `}
  &:focus {
    border-color: #fc83bb;
  }
  &::placeholder {
    color: silver;
    transition: all 0.3s ease;
  }
  &:focus::placeholder {
    color: lightgray;
  }
`;
export const ChatButton = styled.button`
  width: 100%;
  height: 100%;
  padding-left: 20px;
  border: 1px solid lightgray;
  outline: none;
  border-radius: 10px;
  font-size: 16px;
  border: none;
  color: #fff;
  font-size: 18px;
  font-weight: 500;
  cursor: pointer;
  background: -webkit-linear-gradient(left, #a445b2, #fa4299);
  transition: all 0.3s ease;
  ${(props: IButtonProps) => props.disabled && ` opacity: 0.5;`}
  display: ${(props: IButtonProps) => (props.display ? "block" : "none")};
  &:active {
    transform: scale(0.97);
  }
`;
export const SentButton = styled.button`
  width: 100%;
  height: 100%;
  padding-left: 20px;
  border: 1px solid lightgray;
  outline: none;
  border-radius: 10px;
  font-size: 16px;
  border: none;
  color: #fff;
  font-size: 18px;
  font-weight: 500;
  cursor: pointer;
  background: -webkit-linear-gradient(left, #a445b2, #fa4299);
  transition: all 0.3s ease;
  ${(props: IButtonProps) => props.disabled && ` opacity: 0.5;`}
  display: ${(props: IButtonProps) => (props.display ? "block" : "none")};
  &:active {
    transform: scale(0.97);
  }
`;
export const SelectGroup = styled.select`
  width: 100%;
  height: 100%;
  padding-left: 20px;
  border: 1px solid lightgray;
  outline: none;
  border-radius: 10px;
  font-size: 16px;
`;
export const OptionGroup = styled.option``;
