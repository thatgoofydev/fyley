import React, { FC } from "react";
import "./SidePanel.scss";
import classNames from "classnames";

export interface IProps {
  isOpen: boolean;
  onClose?: () => void;
  "data-testid"?: string;
}

export const SidePanel: FC<IProps> = ({ isOpen, onClose, children, "data-testid": testId }) => {
  const handleMaskClick = () => {
    if (onClose) onClose();
  };

  return (
    <>
      <div className={classNames("sidepanel-wrapper", { closed: !isOpen })} data-testid={testId}>
        <div className="mask" onClick={handleMaskClick} />
        <div className="sidepanel">{children}</div>
      </div>
    </>
  );
};
