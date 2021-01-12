import React from "react";
import { Meta, Story } from "@storybook/react";
import { Form } from "./Form";
import { Field } from "./Field";
import { FormActions, FormErrors } from "./types";
import { Button } from "../Button";
import { FormControl } from "./FormControl";
import { BasicField } from "./Field/BasicField/BasicField";
import { SelectField } from "./Field/SelectField/SelectField";

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
  };

  const onValidate = (values: FormModel) => {
    const errors: FormErrors<FormModel> = {};

    if (!values.name) {
      errors.name = "Name is required";
    }

    return errors;
  };

  const onSubmit = async (values: FormModel, actions: FormActions) => {
    await sleep(1500);
    await actions.displaySuccess();
    console.log(values);
  };

  return (
    <Form initialValues={initialValues} onValidate={onValidate} onSubmit={onSubmit}>
      <Field name="name" label="Full name" placeholder="John Doe" />
      <Field type="date" name="date" label="Date" />

      <Field type="select" name="select" label="Select" showSelect>
        <option value="a">a</option>
        <option value="b">b</option>
        <option value="c">c</option>
      </Field>

      <FormControl>
        <Button label="Submit" type="submit" />
      </FormControl>
    </Form>
  );
};
FormStory.storyName = "Form";
