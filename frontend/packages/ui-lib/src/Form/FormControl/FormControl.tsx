import React, { FunctionComponent } from "react";
import styles from "./FormControl.module.scss";
import classNames from "classnames";

interface IFormControlProps {
  children: React.ReactNode;
  className?: string;
}

export const FormControl: FunctionComponent<IFormControlProps> = ({ className, children }) => {
  const classes = classNames(styles.formControlWrapper, className);
  return <div className={classes}>{children}</div>;
};
