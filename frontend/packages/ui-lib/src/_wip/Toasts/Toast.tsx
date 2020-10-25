import React, { FunctionComponent, ReactNode as Node } from "react";

export interface ToastProps {
  id: number;
  content: Node;
  options?: ToastOptions;
}

export interface ToastOptions {
  autoDismiss?: boolean;
  autoDismissTime?: number;
}

export const Toast: FunctionComponent<ToastProps> = ({
  content,
  options = { autoDismiss: true, autoDismissTime: 2000 },
}) => {
  return (
    <>
      <div>Toaster: {content}</div>
    </>
  );
};
