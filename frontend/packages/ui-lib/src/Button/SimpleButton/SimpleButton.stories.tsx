import React from "react";
import { Meta, Story } from "@storybook/react";
import { SimpleButton, ISimpleButtonProps } from "./SimpleButton";

export default {
  title: "Buttons/Simple",
  component: SimpleButton
} as Meta;

export const SimpleButtonStory: Story<ISimpleButtonProps> = args => {
  return <SimpleButton {...args} />;
};
SimpleButtonStory.storyName = "Simple";
SimpleButtonStory.args = {
  label: "Button",
  type: "button",
  disabled: false
};
