import React from "react";
import { Meta, Story } from "@storybook/react";
import { PageTitleProvider } from "./PageTitleProvider";

export default {
  title: "Pages/Title",
  decorators: [
    StoryFn => {
      return (
        <PageTitleProvider>
          <StoryFn />
        </PageTitleProvider>
      );
    }
  ]
} as Meta;

export const PageTitle: Story = _ => {
  return (
    <>
      <PageTitle />
    </>
  );
};
