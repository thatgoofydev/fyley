import React from "react";
import { Meta, Story } from "@storybook/react";
import { Loader } from "./Loader";

export default {
  title: "General/Loader"
} as Meta;

const LoaderStory: Story = _ => {
  return <Loader />;
};
LoaderStory.storyName = "Loader";

export { LoaderStory };
