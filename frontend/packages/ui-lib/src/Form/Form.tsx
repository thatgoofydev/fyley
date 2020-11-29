import React, { FunctionComponent, useState } from "react";
import { FormValues, IFieldState, IFormContext, IFormState } from "./types";
import { FormContext } from "./FormContext";

interface IFormProps {
  onSubmit: (values: FormValues) => void;
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
    touched: {}
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

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const newTouched = state.touched;
    Object.keys(newTouched).forEach(key => (newTouched[key] = true));

    const newState = {
      ...state,
      touched: newTouched,
      errors: onValidate(state.values)
    };

    setState(newState);

    console.log(newState.errors);
    if (!newState.errors || Object.keys(newState.errors).length === 0) {
      onSubmit(newState.values);
    }
  };

  const context: IFormContext = {
    state,
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
