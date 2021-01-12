import React, { FunctionComponent } from "react";
import classNames from "classnames";

import styles from "./FormControl.module.scss";

interface IFormControlProps {
  children: React.ReactNode;
  className?: string;
}

export const FormControl: FunctionComponent<IFormControlProps> = ({ className, children }) => {
  const classes = classNames(styles.formControlWrapper, className);
  return <div className={classes}>{children}</div>;
};
