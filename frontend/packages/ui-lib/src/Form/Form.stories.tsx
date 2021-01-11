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

interface FormModel {
  name: string;
  email?: Date;
}

interface Something {
  test: string;
}

export const FormStory: Story = _ => {

  const initialValues: FormModel = {
    name: ""
  }

  const onValidate = (values: FormModel) => {
    const errors: FormValues = {}

    if (!values.name) {
      errors.name = "Name is required";
    }

    return errors;
  }

  const onSubmit = async (values: FormModel, actions: FormActions) => {
    await sleep(2000);
    await actions.displaySuccess();
    await sleep(2000);
    await actions.displayError();
  }

  return (
    <Form initialValues={initialValues} onValidate={onValidate} onSubmit={onSubmit}>
      <Field name="name" label="Full name" />
      <Field name="email" label="Email" placeholder="hello@example.com" />
      <FormControl>
        <Button label="Submit" type="submit" />
      </FormControl>
    </Form>
  );
};
FormStory.storyName = "Form";
