import React from "react";
import { Meta, Story } from "@storybook/react";
import { LinkButton, LinkButtonProps } from "./LinkButton";

export default {
  title: "Buttons/LinkButton",
  component: LinkButton
} as Meta;

const Template: Story<LinkButtonProps> = args => {
  return <LinkButton {...args} />;
};

export const TextButton = Template.bind({});
TextButton.storyName = "default";
TextButton.args = {
  text: "Button",
  href: "https://google.com",
  icon: undefined
};

export const IconButton = Template.bind({});
IconButton.storyName = "icon";
IconButton.args = {
  text: "New button",
  icon: "add"
};
