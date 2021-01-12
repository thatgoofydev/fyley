import { createContext } from "react";
import { IFormContext, SubmitStatus } from "./types";

const noop = () => {};
const noopAsync = () => Promise.resolve();

export const FormContext = createContext<IFormContext<any>>({
  state: {
    values: {},
    errors: {},
    focused: {},
    touched: {},
    submitStatus: SubmitStatus.IDLE
  },
  actions: {
    displayError: noopAsync,
    displaySuccess: noopAsync
  },
  getFieldState: () => ({
    value: {},
    error: "",
    focused: false,
    touched: false
  }),
  setFieldValue: noop,
  onFieldFocus: noop,
  onFieldBlur: noop
});
