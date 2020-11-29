import React from "react";
import { Meta, Story } from "@storybook/react";
import { Form } from "./Form";
import { Field } from "./Field";
import { FormActions, FormValues } from "./types";
import { Button } from "../Button";
import { FormControl } from "./FormControl";

export default {
  title: "Form/Form",
  component: Form,
  subcomponents: {
    Field
  }
} as Meta;

function sleep(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

export const FormStory: Story = _ => {
  const handleSubmit = async (values: FormValues, actions: FormActions) => {
    await sleep(2000);

    await actions.displaySuccess();

    console.log("submitted:");
    console.log(values);
  };

  const handleValidate = (values: FormValues): FormValues => {
    const errors: FormValues = {};

    if (!values.email) {
      errors.email = "Email is required";
    }

    return errors;
  };

  const initialValues: FormValues = {
    name: "John Doe"
  };

  return (
    <Form onSubmit={handleSubmit} onValidate={handleValidate} initialValues={initialValues}>
      <Field name="name" label="Full name" />
      <Field name="email" label="Email" placeholder="hello@example.com" />
      <FormControl>
        <Button label="Submit" type="submit" />
      </FormControl>
    </Form>
  );
};
FormStory.storyName = "Form";
