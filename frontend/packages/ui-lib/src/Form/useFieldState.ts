import { useContext } from "react";
import { FormContext } from "./FormContext";
import { IFieldState } from "./types";

interface FormStateActions {
  inContext: boolean;
  onChange: (value: any) => void;
  onFocus: () => void;
  onBlur: () => void;
}

const noop = () => {};
export const useFieldState = (name: string): FormStateActions & IFieldState => {
  const context = useContext(FormContext);

  if (!context) {
    return {
      inContext: false,
      onChange: noop,
      onFocus: noop,
      onBlur: noop,

      value: undefined,
      error: undefined,
      focused: false,
      touched: false
    };
  }

  const onChange = (value: any) => context.setFieldValue(name, value);
  const onFocus = () => context.onFieldFocus(name);
  const onBlur = () => context.onFieldBlur(name);

  return {
    inContext: true,
    onChange,
    onFocus,
    onBlur,

    ...context.getFieldState(name)
  };
};
