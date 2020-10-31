import React from "react";
import { render, cleanup } from "@testing-library/react";
import { List, ListItem } from "./List";

afterEach(cleanup);

describe("Loader", function () {
  test("should render with normal", () => {
    const rendered = render(
      <List>
        <ListItem>Item 1</ListItem>
        <ListItem>Item 2</ListItem>
        <ListItem>Item 3</ListItem>
        <ListItem>Item 4</ListItem>
      </List>
    );

    expect(rendered).toMatchSnapshot();
  });

  test("should render without spacing when type=compact", () => {
    const rendered = render(
      <List type="compact">
        <ListItem>Item 1</ListItem>
        <ListItem>Item 2</ListItem>
        <ListItem>Item 3</ListItem>
        <ListItem>Item 4</ListItem>
      </List>
    );

    expect(rendered).toMatchSnapshot();
  });
});
