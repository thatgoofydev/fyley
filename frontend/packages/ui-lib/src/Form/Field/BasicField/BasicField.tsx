import React, { VoidFunctionComponent } from "react";
import { FormControl } from "../../FormControl";
import { useFieldState } from "../../useFieldState";

import styles from "./BasicField.module.scss";

type BasicFieldTypes =
  | "date"
  | "email"
  | "month"
  | "number"
  | "password"
  | "search"
  | "tel"
  | "text"
  | "time"
  | "url"
  | "week";

export type BasicFieldProps = {
  type?: BasicFieldTypes;
  name: string;
  label: string;
  placeholder?: string;
};

export const BasicField: VoidFunctionComponent<BasicFieldProps> = ({
  type = "text",
  name,
  label,
  placeholder
}) => {
  const { inContext, disabled, onChange, onFocus, onBlur, value, error, showError } = useFieldState(
    name
  );

  if (!inContext) {
    console.error("Field should be used inside a 'Form' component");
    return <></>;
  }

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => onChange(event.target.value);

  return (
    <FormControl>
      <label className={styles.label} htmlFor={name}>
        {label}
      </label>
      <input
        className={styles.input}
        id={name}
        type={type}
        name={name}
        value={value ?? ""}
        placeholder={placeholder}
        onChange={handleChange}
        onFocus={onFocus}
        onBlur={onBlur}
        disabled={disabled}
        autoComplete="off"
      />
      {showError && <p className={styles.errorText}>{error}</p>}
    </FormControl>
  );
};
