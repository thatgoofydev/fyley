import React from "react";
import { Meta, Story } from "@storybook/react";
import { Page } from "../Page";
import { PageLoader } from "./PageLoader";

export default {
  title: "Pages/PageLoader",
  component: PageLoader
} as Meta;

export const PageLoaderStory: Story = args => {
  return (
    <Page title="Page title">
      <PageLoader />
    </Page>
  );
};
PageLoaderStory.storyName = "Loader";
