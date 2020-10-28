import React from "react";
import { Meta, Story } from "@storybook/react";
import { Icon, IconProps } from "./Icon";

export default {
  title: "General/Icons",
  component: Icon
} as Meta;

export const IconTemplate: Story<IconProps> = args => {
  return <Icon {...args} />;
};
IconTemplate.storyName = "Icon";
IconTemplate.args = {
  type: "add",
  size: 24
};
