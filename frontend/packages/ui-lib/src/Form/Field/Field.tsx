import React, { FunctionComponent } from "react";
import { useFieldState } from "../useFieldState";
import styles from "./Field.module.scss";
import classNames from "classnames";
import { FormControl } from "../FormControl/FormControl";

interface IFieldProps {
  name: string;
  label: string;
  placeholder?: string;
}

export const Field: FunctionComponent<IFieldProps> = ({ name, label, placeholder }) => {
  const { inContext, onChange, onFocus, onBlur, value, error, focused, touched } = useFieldState(
    name
  );

  if (!inContext) {
    console.error("Field should be used inside a 'Form' component");
    return <></>;
  }

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => onChange(event.target.value);

  const showError = error && touched;
  const classes = classNames({ [styles.error]: showError });
  return (
    <>
      <FormControl className={classes}>
        <div className={styles.formControl}>
          <label htmlFor={name}>{label}</label>
          <input
            id={name}
            type="text"
            name={name}
            value={value || ""}
            placeholder={placeholder}
            onChange={handleChange}
            onFocus={onFocus}
            onBlur={onBlur}
            autoComplete="off"
          />
        </div>
        {showError && <p className={styles.errorText}>{error}</p>}
      </FormControl>
    </>
  );
};
