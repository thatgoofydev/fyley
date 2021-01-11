import React, { ReactElement, ReactNode, useState } from "react";
import {
  FormActions,
  FormValues,
  IFieldState,
  IFormContext,
  IFormState,
  SubmitStatus
} from "./types";
import { FormContext } from "./FormContext";

interface IFormProps<T> {
  initialValues?: T;
  onValidate: (values: T) => FormValues;
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

  const getFieldState = (name: string): IFieldState => {
    if (state.touched[name] == undefined) {
      // Key needs to be set to allow onSubmit to set them all to true.
      state.touched[name] = false;
    }

    return {
      value: state.values ? (state.values as any)[name] : undefined,
      error: state.errors[name],
      focused: state.focused[name],
      touched: state.touched[name]
    };
  };

  const setFieldValue = (name: string, value: any) => {
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

  const onFieldFocus = (name: string) => {
    setState(prevState => ({
      ...prevState,
      focused: {
        ...prevState.focused,
        [name]: true
      }
    }));
  };

  const onFieldBlur = (name: string) => {
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
    Object.keys(newTouched).forEach(key => (newTouched[key] = true));

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
