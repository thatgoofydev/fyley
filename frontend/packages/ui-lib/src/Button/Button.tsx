import React, { VoidFunctionComponent } from "react";
import { SimpleButton } from "./SimpleButton/SimpleButton";
import { StateButton } from "./StateButton/StateButton";
import { useFormSubmit } from "../Form/useFormSubmit";

export type ButtonColors = "normal" | "danger" | "warning";

export interface ButtonProps {
  label: string;
  color?: ButtonColors;
  type?: "submit" | "reset" | "button";
  disabled?: boolean;
  name?: string;
  onClick?: () => void;
  className?: string;
  "data-testid"?: string;
}

export const Button: VoidFunctionComponent<ButtonProps> = ({ ...props }) => {
  const { inFormContext } = useFormSubmit();

  if (inFormContext) {
    return <StateButton {...props} />;
  }

  return <SimpleButton {...props} />;
};
