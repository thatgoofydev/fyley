import React, { FunctionComponent, useContext } from "react";
import { FormContext } from "./Form";
import "./Field.scss";
import classNames from "classnames";

interface FieldProps {
  name: string;
  type: "text" | "date";
  label?: string;
}

export const Field: FunctionComponent<FieldProps> = ({
  name,
  type,
  label = name
}) => {
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
