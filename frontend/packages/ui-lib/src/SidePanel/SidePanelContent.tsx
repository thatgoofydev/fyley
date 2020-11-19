import React, { FC } from "react";
import "./SidePanelContent.scss";

export const SidePanelContent: FC = ({ children }) => {
  return <div className="sidepanel-content">{children}</div>;
};
