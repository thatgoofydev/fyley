import React, { useEffect, useState } from "react";
import { Meta, Story } from "@storybook/react";
import { LinkButton, IProps } from "./LinkButton";

export default {
  title: "Buttons/LinkButton",
  component: LinkButton
} as Meta;

const Template: Story<IProps> = args => {
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

export const OnClickExample: Story<IProps> = args => {
  const [state, setState] = useState<string[]>([]);

  const add = () => {
    setState([...state, `${new Date().toString()} - new message`]);
  };

  return (
    <>
      <LinkButton {...args} onClick={add} />
      {state.map(message => (
        <p key={message}>{message}</p>
      ))}
    </>
  );
};
OnClickExample.storyName = "on click";
OnClickExample.args = {
  text: "Add Message",
  icon: "add"
};
