import React, { MouseEvent, VoidFunctionComponent } from "react";
import { useFormSubmit } from "../../Form/useFormSubmit";
import classNames from "classnames";
import { SubmitStatus } from "../../Form/types";

import styles from "../ButtonBase.module.scss";
import stateStyles from "./StateButton.module.scss";

export type StateButtonProps = {
  label: string;
  disabled?: boolean;
  name?: string;
  onClick?: () => void;
  className?: string;
  "data-testid"?: string;
};

export const StateButton: VoidFunctionComponent<StateButtonProps> = ({
  label,
  disabled,
  name,
  onClick,
  className,
  "data-testid": dataTestId
}) => {
  const { inFormContext, status } = useFormSubmit();

  if (!inFormContext) {
    console.error("State button can only be used in Form components");
    return <></>;
  }

  const classes = classNames(className, styles.button, {
    [stateStyles.submitting]: inFormContext && status === SubmitStatus.SUBMITTING,
    [stateStyles.success]: inFormContext && status === SubmitStatus.SUCCESS,
    [stateStyles.error]: inFormContext && status === SubmitStatus.ERROR
  });

  const handleClick = (event: MouseEvent) => {
    if (status !== SubmitStatus.IDLE) {
      return event.preventDefault();
    }

    if (onClick) onClick();
  };

  return (
    <button
      className={classes}
      type="submit"
      disabled={disabled}
      name={name}
      onClick={handleClick}
      data-testid={dataTestId}
    >
      {label}
      {status === SubmitStatus.SUCCESS && (
        <svg xmlns="http://www.w3.org/2000/svg" width={18} height={18} viewBox="0 0 24 24">
          <path d="M20.3 2L9 13.6l-5.3-5L0 12.3 9 21 24 5.7z" />
        </svg>
      )}
      {status === SubmitStatus.ERROR && (
        <svg xmlns="http://www.w3.org/2000/svg" width={18} height={18} viewBox="0 0 24 24">
          <path d="M24 20.2L15.7 12l8.2-8.3L20.2 0 12 8.3 3.7.1 0 3.8 8.3 12 .1 20.3 3.8 24l8.2-8.3 8.3 8.2z" />
        </svg>
      )}
    </button>
  );
};
