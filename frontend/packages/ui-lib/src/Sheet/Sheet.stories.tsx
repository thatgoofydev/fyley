import React from "react";
import { Meta, Story } from "@storybook/react";
import { Sheet, SheetContent, SheetHeader } from "./Sheet";
import { LinkButton } from "../LinkButton";

export default {
  title: "General/Sheet",
  component: Sheet,
  subcomponents: {
    SheetHeader,
    SheetContent
  }
} as Meta;

const FullSheet: Story = _ => {
  return (
    <Sheet>
      <SheetHeader
        title="Sheet Title"
        buttons={<LinkButton text="Add something" icon="add" />}
      />
      <SheetContent>
        <p>Some content inside of the sheet...</p>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ad aperiam
          assumenda commodi, consectetur, cupiditate et illo, laborum minus
          nihil officia porro provident quidem quisquam ratione recusandae sit
          ut? Perspiciatis, voluptas.
        </p>
        <p>
          A atque consequatur consequuntur cupiditate deleniti dolorem earum
          omnis, quasi quis ratione sed, tempora veritatis voluptas! A ad animi
          beatae dolor dolore doloremque dolores facilis ipsam, nesciunt odio
          quasi quisquam.
        </p>
      </SheetContent>
    </Sheet>
  );
};
FullSheet.storyName = "Sheet";

export { FullSheet };
