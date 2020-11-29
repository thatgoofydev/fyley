import React from "react";
import { cleanup, render } from "@testing-library/react";
import { Form } from "./Form";
import { Field } from "./Field";

const noop = () => {};
const noValidate = () => ({});

afterEach(cleanup);

describe("Form", function () {
  it("should render", function () {
    const { container } = render(
      <Form onSubmit={noop} onValidate={noValidate}>
        <Field name="name" label="Name" />
      </Form>
    );

    expect(container).toMatchSnapshot();
  });

  it("should render with initial values", function () {
    const { container } = render(
      <Form onSubmit={noop} onValidate={noValidate} initialValues={{ name: "john" }}>
        <Field name="name" label="Name" />
      </Form>
    );

    expect(container).toMatchSnapshot();
  });
});
