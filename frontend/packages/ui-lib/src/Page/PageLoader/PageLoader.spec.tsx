import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Page } from "../Page";
import { PageLoader } from "./PageLoader";

afterEach(cleanup);

describe("PageLoader", () => {
  it("should render", () => {
    const { container } = render(
      <Page title={"Page title"}>
        <PageLoader />
      </Page>
    );

    expect(container).toMatchSnapshot();
  });
});
