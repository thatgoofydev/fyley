import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Page } from "../Page";
import { PageError } from "./PageError";
import { PageContent } from "../PageContent/PageContent";

afterEach(cleanup);

describe("PageError", function () {
  it("should render", function () {
    const { container } = render(
      <Page title="Page title">
        <PageContent>
          <PageError />
        </PageContent>
      </Page>
    );

    expect(container).toMatchSnapshot();
  });

  describe("with details", function () {
    it("should render closed", function () {
      const { container } = render(
        <Page title="Page title">
          <PageContent>
            <PageError details="Some details about the error that occurred" />
          </PageContent>
        </Page>
      );

      expect(container).toMatchSnapshot();
    });

    it("should render opened when toggle clicked", function () {
      const { container, getByTestId, getByText } = render(
        <Page title="Page title">
          <PageContent>
            <PageError details="Some details about the error that occurred" />
          </PageContent>
        </Page>
      );

      getByTestId("error-toggle").click();
      expect(getByText("Some details about the error that occurred")).not.toBeNull();
      expect(container).toMatchSnapshot();
    });
  });
});
