import React, { FunctionComponent } from "react";
import { Meta, Story } from "@storybook/react";
import { ToastProvider, useToasts } from "./ToastProvider";

export default {
  title: "Hooks/Toasts"
} as Meta;

const ToastForm: FunctionComponent = () => {
  const { addToast } = useToasts();

  const doAddToast = () => {
    addToast(<>Test node content</>);
  };

  return (
    <>
      <button onClick={() => doAddToast()}>AddToast</button>
    </>
  );
};

export const Toast: Story = () => {
  return (
    <>
      <ToastProvider position="bottom-center">
        <div style={{ height: "200px" }}>
          <ToastForm />
        </div>
      </ToastProvider>
    </>
  );
};
