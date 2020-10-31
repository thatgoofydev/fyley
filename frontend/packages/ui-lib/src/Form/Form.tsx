import React, { FC, FunctionComponent, useState } from "react";
import { IFormState, FormValues, IFieldState } from "./types";
import { FormContext, FormContextType } from "./FormContext";

interface IProp {
  // children: ((state: ChildProps) => React.ReactNode) | React.ReactNode;
  onSubmit: (values: FormValues) => void;
  onValidate: (values: FormValues) => FormValues;
  initialValues?: FormValues;
}

export const Form: FC<IProp> = ({
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

  const setValue = (name: string, value: string) => {
    setState({
      ...state,
      values: {
        ...state.values,
        [name]: value
      },
      errors: {
        ...state.errors,
        [name]: undefined
      }
    });
  };

  const getField = (name: string): IFieldState => {
    return {
      value: state.values[name],
      error: state.errors[name],
      focused: state.focused[name],
      touched: state.touched[name]
    };
  };

  const handleFocus = (name: string) => {
    setState({
      ...state,
      focused: {
        ...state.focused,
        [name]: true
      }
    });
  };

  const handleBlur = (name: string) => {
    const errors = onValidate(state.values) ?? {};

    setState(prev => ({
      ...prev,
      focused: {
        ...state.focused,
        [name]: false
      },
      touched: {
        ...state.touched,
        [name]: true
      },
      errors
    }));
  };

  const context: FormContextType = {
    ...state,
    setValue,
    getField,
    handleFocus,
    handleBlur
  };

  const handleFormSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const errors = onValidate(state.values) ?? {};
    if (Object.keys(errors).length != 0) {
      setState(prev => ({ ...prev, errors }));
    }

    onSubmit(state.values);
  };

  return (
    <FormContext.Provider value={context}>
      <form onSubmit={handleFormSubmit} autoComplete="off">
        {children}
      </form>
    </FormContext.Provider>
  );
};
