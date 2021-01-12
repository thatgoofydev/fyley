import React, { FunctionComponent } from "react";
import { BasicField, BasicFieldProps } from "./BasicField/BasicField";
import { SelectField, SelectFieldProps } from "./SelectField/SelectField";

interface IFieldProps {
  name: string;
  label: string;
  placeholder?: string;
}

export type FieldProps = BasicFieldProps | SelectFieldProps;

export const Field: FunctionComponent<FieldProps> = ({ type, ...props }) => {
  if (type === "select") {
    return <SelectField {...props} />;
  }

  return <BasicField type={type} {...props} />;
};
