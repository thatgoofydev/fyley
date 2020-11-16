import { useApi } from "@fyley/utils";

export interface TransactionsOverview {
  transactions: TransactionDto[];
}

export interface TransactionDto {
  transactionId: string;
  payor: AccountDetails;
  payee: AccountDetails;
  amount: number;
  reference: string;
  occuredOn: string;
}

export interface AccountDetails {
  name: string;
  accountNumber: string;
}

export const useTransactionsOverview = () => {
  const url = "/transactions/list";
  return useApi<TransactionsOverview>(url);
};
