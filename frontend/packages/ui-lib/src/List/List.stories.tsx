import React from "react";
import { Meta, Story } from "@storybook/react";
import { List, ListItem, IProps } from "./List";

export default {
  title: "General/List",
  component: List,
  subcomponents: {
    ListItem
  }
} as Meta;

export const TextList: Story<IProps> = args => {
  return (
    <List {...args}>
      <ListItem>Item 1</ListItem>
      <ListItem>Item 2</ListItem>
      <ListItem>Item 3</ListItem>
      <ListItem>Item 4</ListItem>
    </List>
  );
};
TextList.args = {
  type: "normal"
};
