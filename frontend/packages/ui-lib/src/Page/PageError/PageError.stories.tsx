import React from "react";
import { Meta, Story } from "@storybook/react";
import { Page } from "../Page";
import { IPageErrorProps, PageError } from "./PageError";

export default {
  title: "Pages/PageError",
  component: PageError
} as Meta;

export const PageErrorStory: Story<IPageErrorProps> = args => {
  return (
    <Page title="Page title">
      <PageError {...args} />
    </Page>
  );
};
PageErrorStory.storyName = "Message details";
PageErrorStory.args = {
  details: "some message giving more insight into the error",
  backLink: "#"
};
