import React from "react";
import { Meta, Story } from "@storybook/react";
import { IPageProps, Page } from "./Page";
import { PageContent } from "./PageContent";

export default {
  title: "Pages/Page",
  component: Page
} as Meta;

export const PageStory: Story<IPageProps> = args => {
  return (
    <Page {...args}>
      <PageContent>
        <p>Some content</p>
        <p>Some content</p>
      </PageContent>
    </Page>
  );
};
PageStory.storyName = "Page";
PageStory.args = {
  title: "Page title"
};
