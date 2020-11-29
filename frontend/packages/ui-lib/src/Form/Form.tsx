import React, { FunctionComponent, useState } from "react";
import {
  FormActions,
  FormValues,
  IFieldState,
  IFormContext,
  IFormState,
  SubmitStatus
} from "./types";
import { FormContext } from "./FormContext";

interface IFormProps {
  onSubmit: (values: FormValues, actions: FormActions) => void;
  onValidate: (values: FormValues) => FormValues;
  initialValues?: FormValues;
}

export const Form: FunctionComponent<IFormProps> = ({
  onSubmit,
  onValidate,
  initialValues,
  children
}) => {
  const [state, setState] = useState<IFormState>({
    values: initialValues || {},
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
      value: state.values[name],
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

    await sleep(1000);

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

    const newState: IFormState = {
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

  const context: IFormContext = {
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
