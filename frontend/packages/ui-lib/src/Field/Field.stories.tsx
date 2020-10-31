import React from "react";
import { Meta, Story } from "@storybook/react";
import { Form } from "../Form";
import { Field, IProps } from "./Field";

export default {
  title: "Form/Fields",
  component: Field
} as Meta;

export const FieldStory: Story<IProps> = args => {
  return (
    <Form onSubmit={() => {}} onValidate={() => ({})}>
      <Field {...args} />

      <button type="submit">Submit</button>
    </Form>
  );
};
FieldStory.storyName = "Field";
FieldStory.args = {
  name: "Full Name",
  type: "text"
};

export const AllFields: Story = _ => {
  return (
    <Form onSubmit={() => {}} onValidate={() => ({})}>
      <Field name="date" type="date" />
      <Field name="datetime-local" type="datetime-local" />
      <Field name="email" type="email" />
      <Field name="month" type="month" />
      <Field name="number" type="number" />
      <Field name="password" type="password" />
      <Field name="search" type="search" />
      <Field name="tel" type="tel" />
      <Field name="text" type="text" />
      <Field name="time" type="time" />
      <Field name="url" type="url" />
      <Field name="week" type="week" />

      <button type="submit">Submit</button>
    </Form>
  );
};
