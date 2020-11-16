import { useApi } from "@fyley/utils";

export interface TransactionsOverview {
  transactions: TransactionDto[];
}

export interface TransactionDto {
  transactionId: string;
  otherName: string;
  otherAccountNumber: string;
  amount: number;
  reference: string;
  occuredOn: string;
}

export interface AccountDetails {
  name: string;
  accountNumber: string;
}

export const useTransactionsOverview = () => {
  const url = "/transactions/overview";
  return useApi<TransactionsOverview>(url);
};
