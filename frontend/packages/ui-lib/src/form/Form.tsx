import React, { FunctionComponent, useEffect, useState } from "react";

export interface FormValues<T = any> {
  [field: string]: T;
}

interface FormProp {
  children: ((state: ChildProps) => React.ReactNode) | React.ReactNode;
  onSubmit: (values: FormValues) => void;
  onValidate: (values: FormValues) => FormValues;
  initialValues?: FormValues;
}

interface FormState {
  values: FormValues;
  errors: FormValues;
  focused: FormValues<boolean>;
  touched: FormValues<boolean>;
}

interface ChildFunctions {
  getField: (name: string) => FieldState;
}

type ChildProps = FormState & ChildFunctions;

interface FieldState {
  value: any;
  error: any;
  focused: boolean;
  touched: boolean;
}

interface IFormContext {
  setValue: (name: string, value: string) => void;
  getField: (name: string) => FieldState;
  handleFocus: (name: string) => void;
  handleBlur: (name: string) => void;
}

type FormContextType = (IFormContext & FormState) | null;

export const FormContext = React.createContext<FormContextType>(null);

export const Form: FunctionComponent<FormProp> = ({
  children,
  onSubmit,
  onValidate,
  initialValues
}) => {
  const [state, setState] = useState<FormState>({
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

  const getField = (name: string): FieldState => {
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

  const childProps: ChildProps = {
    ...state,
    getField
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const errors = onValidate(state.values) ?? {};
    if (Object.keys(errors).length != 0) {
      setState(prev => ({ ...prev, errors }));
    }

    onSubmit(state.values);
  };

  // useEffect(() => {
  //   const errors = onValidate(state.values) ?? {};
  //   if (Object.keys(errors).length != 0) {
  //     setState(prev => ({ ...prev, errors }));
  //   }
  // }, [state.values]);

  return (
    <FormContext.Provider value={context}>
      <form onSubmit={handleSubmit} autoComplete="off">
        {typeof children == "function"
          ? (children as (data: ChildProps) => React.ReactNode)(childProps)
          : children}
      </form>
    </FormContext.Provider>
  );
};
