import React, { FunctionComponent } from "react";
import "./Sheet.scss";

export const Sheet: FunctionComponent = ({ children }) => {
  return <div className={"sheet"}>{children}</div>;
};
