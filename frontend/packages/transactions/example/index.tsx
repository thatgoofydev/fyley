import React, { FC, useImperativeHandle, useState } from "react";
import ReactDom from "react-dom";
import { TransactionsOverview } from "../src/TransactionsOverview";
import "./index.scss";
import { LinkButton, Sheet, SheetContent, SheetHeader } from "@fyley/ui-lib";
import fetchMock from "fetch-mock";
import { BrowserRouter, Route, Switch, NavLink } from "react-router-dom";

enum ExampleState {
  NONE,
  OVERVIEW
}

fetchMock.post("path:/bff/desktop/transactions/overview", {
  body: JSON.stringify({
    ok: true,
    data: {
      transactions: [
        {
          transactionId: "ceb24fc2-a29f-4ee0-ad39-aaa9c04e8ee3",
          otherName: "King Carol",
          otherAccountNumber: "BE90 8173 3352 6832",
          amount: -20,
          reference: "Bought carol songs?",
          occuredOn: "18-11-2020"
        },
        {
          transactionId: "ceb24fc2-a29f-4ee0-ad39-aaa9c04e8ee1",
          otherName: "King Carol",
          otherAccountNumber: "BE90 8173 3352 6832",
          amount: 15.2,
          reference: "Bought carol songs?",
          occuredOn: "18-11-2020"
        },
        {
          transactionId: "ceb24fc2-a29f-4ee0-ad39-aaa9c04e8ee2",
          otherName: "King Carol",
          otherAccountNumber: "BE90 8173 3352 6832",
          amount: 11.5,
          reference: "Bought carol songs?",
          occuredOn: "18-11-2020"
        },
        {
          transactionId: "ceb24fc2-a29f-4ee0-ad39-aaa9c04e8ee2",
          otherName: "King Carol",
          otherAccountNumber: "BE90 8173 3352 6832",
          amount: -17.03,
          reference: "Bought carol songs?",
          occuredOn: "18-11-2020"
        }
      ]
    }
  })
});

const Example: FC = () => {
  return (
    <main>
      <BrowserRouter>
        <Switch>
          <Route exact path={"/"}>
            <Sheet>
              <SheetHeader title="Transactions" />
              <SheetContent>
                <ul style={{ listStyleType: "none" }}>
                  <li>
                    <NavLink to="/overview">Overview</NavLink>
                  </li>
                </ul>
              </SheetContent>
            </Sheet>
          </Route>
          <Route path="/overview">
            <Sheet>
              <SheetHeader title="Overview" buttons={<NavLink to="/">Back</NavLink>} />
              <SheetContent>
                <TransactionsOverview />
              </SheetContent>
            </Sheet>
          </Route>
        </Switch>
      </BrowserRouter>
    </main>
  );
};

ReactDom.render(<Example />, document.getElementById("root"));
