import React, { FunctionComponent } from "react";
import { TransactionDto, useTransactionsOverview } from "../helpers/api/useTransactionsOverview";
import { RequestState } from "@fyley/utils";
import { Loader } from "@fyley/ui-lib";
import "./TransactionsOverview.scss";
import { formatMoney } from "../helpers/formatters/formatMoney";

export const TransactionsOverview: FunctionComponent = () => {
  const { state, data } = useTransactionsOverview();

  if (state == RequestState.LOADING) {
    return (
      <>
        <Loader />
      </>
    );
  }

  if (state == RequestState.ERROR) {
    return (
      <>
        <h1>error</h1>
      </>
    );
  }

  return (
    <>
      <table>
        <thead>
          <tr>
            <th style={{ width: "120px" }}>Date</th>
            <th>Payee/Payor</th>
            <th className="money">Balance</th>
            <th className="money in">IN</th>
            <th className="money out">OUT</th>
            <th>Tags</th>
            <th>Reference</th>
          </tr>
        </thead>

        <tbody>
          {data.transactions.map(transaction => (
            <tr key={transaction.transactionId}>
              <td>{transaction.occuredOn}</td>
              <td>
                <p>{transaction.otherName}</p>
                <p>{transaction.otherAccountNumber}</p>
              </td>
              <td className="money">-,--</td>
              <td className="money in">
                {transaction.amount > 0 ? formatMoney(transaction.amount) : " -,--"}
              </td>
              <td className="money out">
                {transaction.amount < 0 ? formatMoney(transaction.amount) : " -,--"}
              </td>
              <td>TODO</td>
              <td>{transaction.reference}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
};
