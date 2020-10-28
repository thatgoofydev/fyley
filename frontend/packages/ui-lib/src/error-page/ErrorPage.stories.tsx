import React from "react";
import { Meta, Story } from "@storybook/react";
import { ErrorPage, IProps } from "./ErrorPage";

export default {
  title: "General/ErrorPage",
  component: ErrorPage
} as Meta;

export const Example: Story<IProps> = args => {
  return <ErrorPage {...args} />;
};
Example.args = {
  title: "Oops.. an error occurred.",
  children: (
    <>
      <p>
        Component can be given children to provide the user with more details
        about the error that has occurred.
      </p>
    </>
  )
};
