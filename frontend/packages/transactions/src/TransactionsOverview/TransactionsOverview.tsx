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

  const renderTableRow = (transaction: TransactionDto) => {
    const otherParty = transaction.amount > 0 ? transaction.payor : transaction.payee;
    return (
      <tr key={transaction.transactionId}>
        <td>{transaction.occuredOn}</td>
        <td>
          <p>{otherParty.name}</p>
          <p>{otherParty.accountNumber}</p>
        </td>
        <td className="money">
          {transaction.amount > 0 ? formatMoney(transaction.amount) : " -,--"}
        </td>
        <td className="money">
          {transaction.amount < 0 ? formatMoney(transaction.amount) : " -,--"}
        </td>
        <td>{transaction.reference}</td>
      </tr>
    );
  };

  return (
    <>
      <table>
        <thead>
          <tr>
            <th>Date</th>
            <th>Payee/Payor</th>
            <th>IN</th>
            <th>OUT</th>
            <th>Reference</th>
          </tr>
        </thead>

        <tbody>{data.transactions.map(renderTableRow)}</tbody>
      </table>
    </>
  );
};
