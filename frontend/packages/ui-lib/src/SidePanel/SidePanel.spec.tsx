import React from "react";
import { render, cleanup } from "@testing-library/react";
import { SidePanel } from "./SidePanel";
import { SidePanelHeader } from "./SidePanelHeader";
import { SidePanelContent } from "./SidePanelContent";

afterEach(cleanup);

describe("SidePanel", function () {
  it("should render closed if !isOpen", () => {
    const { container, getByTestId } = render(
      <SidePanel isOpen={false} data-testid="panel">
        <SidePanelHeader title="some title" />
        <SidePanelContent>
          <p>Some content inside of the panel...</p>
        </SidePanelContent>
      </SidePanel>
    );

    expect(container).toMatchSnapshot();
    expect(getByTestId("panel").classList).toContain("closed");
  });

  it("should render open if isOpen", () => {
    const { container, getByTestId } = render(
      <SidePanel isOpen={true} data-testid="panel">
        <SidePanelHeader title="some title" />
        <SidePanelContent>
          <p>Some content inside of the panel...</p>
        </SidePanelContent>
      </SidePanel>
    );

    expect(container).toMatchSnapshot();
    expect(getByTestId("panel").classList).not.toContain("closed");
  });
});
