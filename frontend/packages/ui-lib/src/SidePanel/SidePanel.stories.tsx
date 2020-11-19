import React, { useState } from "react";
import { Meta, Story } from "@storybook/react";
import { SidePanel } from "./SidePanel";
import { Sheet, SheetContent } from "../Sheet";
import { SidePanelHeader } from "./SidePanelHeader";
import { SidePanelContent } from "./SidePanelContent";

export default {
  title: "Pages/SidePanel"
} as Meta;

export const SidePanelExample: Story = _ => {
  const [isOpen, setOpen] = useState(false);

  const openSidePanel = () => setOpen(true);
  const closeSidePanel = () => setOpen(false);

  return (
    <Sheet>
      <SheetContent>
        <button onClick={openSidePanel}>Open SidePanel</button>

        <SidePanel isOpen={isOpen} onClose={closeSidePanel}>
          <SidePanelHeader title="Some title" onClose={closeSidePanel} />
          <SidePanelContent>Some sidebar content</SidePanelContent>
        </SidePanel>
      </SheetContent>
    </Sheet>
  );
};
