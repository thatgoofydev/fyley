import React from "react";
import { Meta, Story } from "@storybook/react";
import { Icon, IProps } from "./Icon";

export default {
    title: "General/Icons",
    component: Icon
} as Meta;

export const IconTemplate: Story<IProps> = args => {
    return <Icon {...args} />;
};
IconTemplate.storyName = "Icon";
IconTemplate.args = {
    type: "add",
    size: 24
};
