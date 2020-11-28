import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Button, IButtonProps } from "./Button";

const defaultProps: IButtonProps = {
  label: "Button"
};

afterEach(cleanup);

describe("Button", function () {
  describe("should render correctly", function () {
    it("when default", function () {
      const { container } = render(<Button {...defaultProps} />);
      expect(container).toMatchSnapshot();
    });

    it("when small size", function () {
      const props: IButtonProps = {
        ...defaultProps,
        size: "small"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    it("when secondary style", function () {
      const props: IButtonProps = {
        ...defaultProps,
        style: "secondary"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    it("when submitting state", function () {
      const props: IButtonProps = {
        ...defaultProps,
        actionState: "submitting"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    it("when success state", function () {
      const props: IButtonProps = {
        ...defaultProps,
        actionState: "success"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    it("when error state", function () {
      const props: IButtonProps = {
        ...defaultProps,
        actionState: "error"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });
  });
});
