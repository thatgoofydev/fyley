import React, { FunctionComponent } from "react";
import styles from "./Button.module.scss";
import classNames from "classnames";
import { useFormSubmit } from "../Form/useFormSubmit";
import { SubmitStatus } from "../Form/types";

export interface IButtonProps {
  label: string;
  style?: "primary" | "secondary";
  type?: "submit" | "button" | "reset";
  size?: "normal" | "small";
  color?: "blue" | "red";
  disabled?: boolean;
  onClick?: () => void;
  "data-testid"?: string;
}

export const Button: FunctionComponent<IButtonProps> = ({
  label,
  style = "primary",
  type = "button",
  size = "normal",
  color = "blue",
  disabled,
  onClick,
  "data-testid": dataTestId
}) => {
  const { inFormContext, status } = useFormSubmit();

  const classes: string = classNames(
    styles.button,
    style === "secondary" ? styles.secondary : undefined,
    size === "small" ? styles.small : undefined,
    styles[color],
    {
      [styles.submitting]: inFormContext && status === SubmitStatus.SUBMITTING,
      [styles.success]: inFormContext && status === SubmitStatus.SUCCESS,
      [styles.error]: inFormContext && status === SubmitStatus.ERROR
    }
  );

  const svgSize = size === "small" ? 18 : 24;
  return (
    <button
      type={type}
      disabled={disabled}
      className={classes}
      onClick={onClick}
      data-testid={dataTestId}
    >
      {label}
      {status === SubmitStatus.SUCCESS && (
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width={svgSize}
          height={svgSize}
          viewBox="0 0 24 24"
        >
          <path d="M20.3 2L9 13.6l-5.3-5L0 12.3 9 21 24 5.7z" />
        </svg>
      )}
      {status === SubmitStatus.ERROR && (
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width={svgSize}
          height={svgSize}
          viewBox="0 0 24 24"
        >
          <path d="M24 20.2L15.7 12l8.2-8.3L20.2 0 12 8.3 3.7.1 0 3.8 8.3 12 .1 20.3 3.8 24l8.2-8.3 8.3 8.2z" />
        </svg>
      )}
    </button>
  );
};
