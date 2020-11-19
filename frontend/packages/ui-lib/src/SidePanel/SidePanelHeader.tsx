import React, { FC } from "react";
import "./SidePanelHeader.scss";

interface IProps {
  title: string;
  onClose?: () => void;
}

export const SidePanelHeader: FC<IProps> = ({ title, onClose }) => {
  const handleCloseClicked = () => {
    if (onClose) onClose();
  };

  return (
    <div className="sidepanel-header">
      <div className="title">
        <h2>{title}</h2>
      </div>
      <div className="close" onClick={handleCloseClicked} />
    </div>
  );
};
