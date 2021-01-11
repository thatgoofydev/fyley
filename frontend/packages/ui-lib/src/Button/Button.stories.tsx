import React from "react";
import { Meta, Story } from "@storybook/react";
import { Button, ButtonProps } from "./Button";
import { Form, FormActions } from "../Form";

export default {
  title: "Buttons/Button",
  component: Button
} as Meta;

export const SimpleButtonStory: Story<ButtonProps> = args => {
  return <Button {...args} />;
};
SimpleButtonStory.storyName = "Simple";
SimpleButtonStory.args = {
  label: "Button",
  type: "button",
  disabled: false,
  color: "normal"
};

export const StateButtonStory: Story<ButtonProps> = args => {
  const noopValidate = () => ({});

  const onSubmit = async (values: any, actions: FormActions) => {
    await sleep(2000);
    await actions.displaySuccess();
  };

  return (
    <Form onSubmit={onSubmit} onValidate={noopValidate}>
      <Button {...args} />
    </Form>
  );
};
StateButtonStory.storyName = "State";
StateButtonStory.args = {
  buttonType: "state",
  label: "Button",
  disabled: false
};

function sleep(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}
