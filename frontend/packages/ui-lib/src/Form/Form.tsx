import React, { ReactElement, ReactNode, useState } from "react";
import {
  FormActions,
  FormErrors,
  IFieldState,
  IFormContext,
  IFormState,
  SubmitStatus
} from "./types";
import { FormContext } from "./FormContext";

interface IFormProps<T> {
  initialValues?: T;
  onValidate: (values: T) => FormErrors<T>;
  onSubmit: (values: T, actions: FormActions) => void | Promise<void>;
}

export const Form = <T extends Object>({
  onSubmit,
  onValidate,
  initialValues,
  children
}: IFormProps<T> & { children?: ReactNode }): ReactElement => {
  const [state, setState] = useState<IFormState<T>>({
    values: initialValues || ({} as T),
    errors: {},
    focused: {},
    touched: {},
    submitStatus: SubmitStatus.IDLE
  });

  const getFieldState = (name: keyof T): IFieldState => {
    if (state.touched[name] == undefined) {
      // Key needs to be set to allow onSubmit to set them all to true.
      state.touched[name] = false;
    }

    return {
      value: state.values[name],
      error: state.errors[name],
      focused: state.focused[name] ? state.focused[name]! : false,
      touched: state.touched[name]!
    };
  };

  const setFieldValue = (name: keyof T, value: any) => {
    const newState = {
      ...state,
      values: {
        ...state.values,
        [name]: value
      }
    };

    newState.errors = onValidate(newState.values);
    setState(newState);
  };

  const onFieldFocus = (name: keyof T) => {
    setState(prevState => ({
      ...prevState,
      focused: {
        ...prevState.focused,
        [name]: true
      }
    }));
  };

  const onFieldBlur = (name: keyof T) => {
    setState(prevState => ({
      ...prevState,
      focused: {
        ...prevState.focused,
        [name]: false
      },
      touched: {
        ...prevState.touched,
        [name]: true
      }
    }));
  };

  const displaySubmitStatus = async (status: SubmitStatus): Promise<void> => {
    setState(prevState => ({
      ...prevState,
      submitStatus: status
    }));

    await sleep(800);

    setState(prevState => ({
      ...prevState,
      submitStatus: SubmitStatus.IDLE
    }));
  };

  const actions: FormActions = {
    displaySuccess: () => displaySubmitStatus(SubmitStatus.SUCCESS),
    displayError: () => displaySubmitStatus(SubmitStatus.ERROR)
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const newTouched = state.touched;
    Object.keys(newTouched).forEach(key => ((newTouched as any)[key] = true));

    const errors = onValidate(state.values);
    const shouldCallback = !errors || Object.keys(errors).length === 0;

    const newState: IFormState<T> = {
      ...state,
      touched: newTouched,
      errors,
      submitStatus: shouldCallback ? SubmitStatus.SUBMITTING : SubmitStatus.IDLE
    };

    setState(newState);

    if (shouldCallback) {
      onSubmit(newState.values, actions);
    }
  };

  const context: IFormContext<T> = {
    state,
    actions,
    getFieldState,
    setFieldValue,
    onFieldFocus,
    onFieldBlur
  };

  return (
    <FormContext.Provider value={context}>
      <form onSubmit={handleSubmit} autoComplete="off">
        {children}
      </form>
    </FormContext.Provider>
  );
};

function sleep(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}
