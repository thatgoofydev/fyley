import React, { VoidFunctionComponent } from "react";
import classNames from "classnames";

import { ButtonColors } from "../Button";
import styles from "../ButtonBase.module.scss";

export type SimpleButtonProps = {
  label: string;
  color?: ButtonColors;
  type?: "submit" | "reset" | "button";
  disabled?: boolean;
  name?: string;
  onClick?: () => void;
  className?: string;
  "data-testid"?: string;
};

export const SimpleButton: VoidFunctionComponent<SimpleButtonProps> = ({
  label,
  color = "normal",
  type,
  disabled,
  name,
  onClick,
  className,
  "data-testid": dataTestId
}) => {
  const classes = classNames(className, styles.button, {
    [styles[color]]: color != "normal"
  });

  return (
    <button
      className={classes}
      type={type}
      disabled={disabled}
      name={name}
      onClick={onClick}
      data-testid={dataTestId}
    >
      {label}
    </button>
  );
};
