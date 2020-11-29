import { createContext } from "react";
import { IFormContext } from "./types";

const noop = () => {};

export const FormContext = createContext<IFormContext>({
  state: {
    values: {},
    errors: {},
    focused: {},
    touched: {}
  },
  getFieldState: () => ({
    value: {},
    error: {},
    focused: false,
    touched: false
  }),
  setFieldValue: noop,
  onFieldFocus: noop,
  onFieldBlur: noop
});
