import React from "react";
import { Meta, Story } from "@storybook/react";
import { Form, FormValues } from "./Form";
import { Field } from "./Field";

export default {
  title: "Form/Example",
  component: Form
} as Meta;

export const FormExample: Story = () => {
  const onSubmit = (values: FormValues) => {
    console.log(values);
  };

  const onValidate = (values: FormValues): FormValues => {
    const errors: FormValues = {};

    if (values.name !== "jeroen") {
      errors.name = "wrong name";
    }

    return errors;
  };

  return (
    <Form
      onSubmit={onSubmit}
      onValidate={onValidate}
      initialValues={{
        name: "jer",
        birthdate: "1998-09-01"
      }}
    >
      <Field label="Full name" name="name" type="text" />
      <Field name="Birthdate" type="date" />
      <button type="submit">Submit</button>
    </Form>
  );
};

export const FormExampleTwo: Story = () => {
  const onSubmit = (values: FormValues) => {
    console.log(values);
  };

  const onValidate = (values: FormValues): FormValues => {
    const errors: FormValues = {};

    if (values.name !== "jeroen") {
      errors.name = "wrong name";
    }

    errors.test = "a test";

    return errors;
  };

  return (
    <Form
      onSubmit={onSubmit}
      onValidate={onValidate}
      initialValues={{
        name: "jer",
        birthdate: "1998-09-01"
      }}
    >
      {({ errors, getField }) => (
        <>
          <Field label="Full name" name="name" type="text" />
          <Field name="Birthdate" type="date" />

          <button type="submit">Submit</button>

          {JSON.stringify(getField("name"))}

          {errors.test && <p>A test error occured</p>}
        </>
      )}
    </Form>
  );
};
