import React, { FunctionComponent } from "react";
import classNames from "classnames";
import "./ToastContainer.scss";

interface ToastContainerProps {
  position?:
    | "top-left"
    | "top-center"
    | "top-right"
    | "bottom-left"
    | "bottom-center"
    | "bottom-right";
}

export const ToastContainer: FunctionComponent<ToastContainerProps> = ({
  children,
  position = "top-right",
}) => {
  return (
    <>
      <div className={classNames("toast-container", position)}>{children}</div>
    </>
  );
};
