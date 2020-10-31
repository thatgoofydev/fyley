import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Sheet, SheetContent, SheetHeader } from "./Sheet";
import { LinkButton } from "../LinkButton";

afterEach(cleanup);

describe("Loader", function () {
  test("should render", () => {
    const rendered = render(
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
            omnis, quasi quis ratione sed, tempora veritatis voluptas! A ad
            animi beatae dolor dolore doloremque dolores facilis ipsam, nesciunt
            odio quasi quisquam.
          </p>
        </SheetContent>
      </Sheet>
    );
    expect(rendered).toMatchSnapshot();
  });
});
