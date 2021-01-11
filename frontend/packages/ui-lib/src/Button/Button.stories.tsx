import React from "react";
import { Meta, Story } from "@storybook/react";
import { Button, IButtonProps } from "./Button";

export default {
  title: "Buttons/Button",
  component: Button
} as Meta;

export const ButtonStory: Story<IButtonProps> = args => {
  return <Button {...args} />;
};
ButtonStory.storyName = "Button";
ButtonStory.args = {
  label: "Button",
  style: "primary",
  size: "normal",
  type: "button",
  color: "blue",
  disabled: false
};
