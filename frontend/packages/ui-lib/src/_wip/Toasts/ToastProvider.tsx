import React, {
  FunctionComponent,
  useContext,
  useState,
  ReactNode as Node
} from "react";
import { Toast, ToastOptions, ToastProps } from "./Toast";
import { canUseDOM } from "./util";
import { createPortal } from "react-dom";
import { ToastContainer } from "./ToastContainer/ToastContainer";

interface ToastContextProps {
  addToast: (content: Node, options?: ToastOptions) => number;
  removeToast: (id: number) => void;
}

const ToastContext = React.createContext<ToastContextProps>({
  addToast: () => {
    console.log("no provider");
    return -1;
  },
  removeToast: () => {}
});

interface ToastProviderProps {
  position?:
    | "top-left"
    | "top-center"
    | "top-right"
    | "bottom-left"
    | "bottom-center"
    | "bottom-right";
}

export const ToastProvider: FunctionComponent<ToastProviderProps> = ({
  children,
  position = "top-right"
}) => {
  const [toasts, setToasts] = useState(new Array<ToastProps>());

  const addToast = (content: Node, options?: ToastOptions): number => {
    const id = Math.floor(Date.now() * Math.random()); // Probably random enough
    const newToast: ToastProps = {
      id,
      content,
      options
    };
    setToasts([...toasts, newToast]);
    return id;
  };

  const removeToast = (id: number) => {
    setToasts(toasts.filter(t => t.id != id));
  };

  return (
    <>
      <ToastContext.Provider value={{ addToast, removeToast }}>
        {children}

        {canUseDOM &&
          createPortal(
            <>
              <ToastContainer position={position}>
                {toasts.map(props => (
                  <Toast key={props.id} {...props} />
                ))}
              </ToastContainer>
            </>,
            document.body
          )}
      </ToastContext.Provider>
    </>
  );
};

export const useToasts = () => {
  const ctx = useContext(ToastContext);

  console.log(ctx);
  return {
    addToast: ctx.addToast
  };
};
