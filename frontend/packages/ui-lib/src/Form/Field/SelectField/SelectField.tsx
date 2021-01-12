import React, { FunctionComponent } from "react";
import { FormControl } from "../../FormControl";
import { useFieldState } from "../../useFieldState";

import styles from "./SelectField.module.scss";
import classNames from "classnames";

export type SelectFieldProps = {
  type?: "select";
  name: string;
  label: string;
  showSelect?: boolean;
};

export const SelectField: FunctionComponent<SelectFieldProps> = ({
  name,
  label,
  showSelect,
  children
}) => {
  const { inContext, disabled, onChange, onFocus, onBlur, value, error, showError } = useFieldState(
    name
  );

  if (!inContext) {
    console.error("Field should be used inside a 'Form' component");
    return <></>;
  }

  const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) =>
    onChange(event.target.value);

  const classes = classNames(styles.select, { [styles.selectOption]: !value });
  return (
    <FormControl>
      <label className={styles.label} htmlFor={name}>
        {label}
      </label>
      <select
        className={classes}
        name={name}
        value={value ?? ""}
        onChange={handleChange}
        onFocus={onFocus}
        onBlur={onBlur}
        disabled={disabled}
      >
        {!value && showSelect && (
          <option className={styles.selectOption} value="" disabled>
            --- Select ---
          </option>
        )}
        {children}
      </select>
      {showError && <p className={styles.errorText}>{error}</p>}
    </FormControl>
  );
};
