import { useContext } from "react";
import { FormContext } from "./FormContext";
import { IFieldState, SubmitStatus } from "./types";

interface FormStateActions {
  inContext: boolean;
  disabled: boolean;
  onChange: (value: any) => void;
  onFocus: () => void;
  onBlur: () => void;
}

const noop = () => {};
export const useFieldState = (
  name: string
): FormStateActions & Omit<IFieldState, "focused" | "touched"> & { showError: boolean } => {
  const context = useContext(FormContext);

  if (!context) {
    return {
      inContext: false,
      disabled: false,
      onChange: noop,
      onFocus: noop,
      onBlur: noop,

      value: undefined,
      error: undefined,
      showError: false
    };
  }

  const onChange = (value: any) => context.setFieldValue(name, value);
  const onFocus = () => context.onFieldFocus(name);
  const onBlur = () => context.onFieldBlur(name);

  const fieldState = context.getFieldState(name);
  const showError = !!fieldState.error && fieldState.touched;

  return {
    inContext: true,
    disabled: context.state.submitStatus !== SubmitStatus.IDLE,
    onChange,
    onFocus,
    onBlur,
    showError,
    ...fieldState
  };
};
