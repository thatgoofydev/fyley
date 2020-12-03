import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Page } from "../Page";
import { PageError } from "./PageError";

afterEach(cleanup);

describe("PageError", function () {
  it("should render", function () {
    const { container } = render(
      <Page title="Page title">
        <PageError />
      </Page>
    );

    expect(container).toMatchSnapshot();
  });

  describe("with details", function () {
    it("should render closed", function () {
      const { container } = render(
        <Page title="Page title">
          <PageError details="Some details about the error that occurred" />
        </Page>
      );

      expect(container).toMatchSnapshot();
    });

    it("should render opened when toggle clicked", function () {
      const { container, getByTestId, getByText } = render(
        <Page title="Page title">
          <PageError details="Some details about the error that occurred" />
        </Page>
      );

      getByTestId("error-toggle").click();
      expect(getByText("Some details about the error that occurred")).not.toBeNull();
      expect(container).toMatchSnapshot();
    });
  });
});
