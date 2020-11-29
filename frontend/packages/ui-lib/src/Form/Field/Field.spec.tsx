import React from "react";
import { cleanup, render } from "@testing-library/react";
import { FormContext } from "../FormContext";
import { Field } from "./Field";
import { FormActions, IFieldState, IFormContext, IFormState, SubmitStatus } from "../types";

const noop = () => {};
const noopAsync = () => Promise.resolve();

const defaultState: IFormState = {
  values: {},
  errors: {},
  touched: {},
  focused: {},
  submitStatus: SubmitStatus.IDLE
};

const defaultActions: FormActions = {
  displaySuccess: noopAsync,
  displayError: noopAsync
};

const defaultContext: IFormContext = {
  state: defaultState,
  actions: defaultActions,
  onFieldBlur: noop,
  onFieldFocus: noop,
  setFieldValue: noop,
  getFieldState: () => ({
    value: undefined,
    error: undefined,
    touched: false,
    focused: false
  })
};

afterEach(cleanup);

describe("Field", function () {
  it("should render", function () {
    const { container, findByText } = render(
      <FormContext.Provider value={defaultContext}>
        <Field name="name" label="Name" />
      </FormContext.Provider>
    );

    expect(findByText("Name")).not.toBeNull();
    expect(container).toMatchSnapshot();
  });

  it("should render error", function () {
    const contextValue = contextWithState({
      ...defaultState,
      errors: {
        name: "Name is required"
      },
      touched: {
        name: true
      }
    });

    const { container, getByText } = render(
      <FormContext.Provider value={contextValue}>
        <Field name="name" label="Name" />
      </FormContext.Provider>
    );

    expect(getByText("Name is required")).not.toBeNull();
    expect(container).toMatchSnapshot();
  });
});

const contextWithState = (state: IFormState): IFormContext => {
  const getFieldState = (name: string): IFieldState => {
    return {
      value: state.values[name],
      error: state.errors[name],
      focused: state.focused[name],
      touched: state.touched[name]
    };
  };

  const setFieldValue = (name: string, value: any) => {
    state = {
      ...state,
      values: {
        ...state.values,
        [name]: value
      }
    };
  };

  const onFieldFocus = (name: string) => {
    state = {
      ...state,
      focused: {
        ...state.focused,
        [name]: true
      }
    };
  };

  const onFieldBlur = (name: string) => {
    state = {
      ...state,
      focused: {
        ...state.focused,
        [name]: false
      },
      touched: {
        ...state.touched,
        [name]: true
      }
    };
  };

  return {
    state,
    actions: defaultActions,
    getFieldState,
    setFieldValue,
    onFieldFocus,
    onFieldBlur
  };
};
