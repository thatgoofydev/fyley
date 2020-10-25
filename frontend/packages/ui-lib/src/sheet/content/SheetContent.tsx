import React, { FunctionComponent } from "react";
import "./SheetContent.scss";

export const SheetContent: FunctionComponent = ({ children }) => {
  return <div className="sheet__content">{children}</div>;
};
