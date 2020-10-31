import React, { FC, useContext } from "react";
import classNames from "classnames";
import { FormContext } from "../Form/FormContext";
import "./Field.scss";

export interface IProps {
  name: string;
  type?:
    | "date"
    | "datetime-local"
    | "email"
    | "month"
    | "number"
    | "password"
    | "search"
    | "tel"
    | "text"
    | "time"
    | "url"
    | "week"
    | undefined;
  label?: string;
}

export const Field: FC<IProps> = ({ name, type = "text", label = name }) => {
  const context = useContext(FormContext);
  if (!context) {
    return <h1>Field can only be used inside a &lt;Form&gt; component</h1>;
  }

  const { value, error, focused, touched } = context.getField(name);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    context.setValue(name, event.target.value);
  };

  const handleFocus = () => {
    context.handleFocus(name);
  };

  const handleBlur = () => {
    context.handleBlur(name);
  };

  const errorState = touched && error;

  const classes = classNames("field", { error: errorState, focused });
  return (
    <>
      <div className={classes}>
        <label>{label}</label>
        <input
          type={type}
          name={name}
          value={value || ""}
          onChange={handleChange}
          onFocus={handleFocus}
          onBlur={handleBlur}
          autoComplete="off"
        />
        <div className="error-spacing">
          {errorState && <span className="error-message">{error}</span>}
        </div>
      </div>
    </>
  );
};
