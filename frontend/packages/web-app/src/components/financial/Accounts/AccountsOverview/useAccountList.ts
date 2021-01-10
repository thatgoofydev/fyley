import { useApi } from "@fyley/utils";

export interface AccountResponse {
  accounts: Account[];
}

export interface Account {
  accountId: string;
  name: string;
  description: string;
  accountNumber: string;
  accountNumberType: AccountNumberType;
}

export enum AccountNumberType {
  IBAN = "Iban",
  OTHER = "Other"
}

export const useAccountList = () => {
  return useApi<AccountResponse>("/accounts/list_accounts");
};
