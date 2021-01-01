import { useApi } from "@fyley/utils";
import { AccountResponse } from "./models";

export const useAccountList = () => {
  return useApi<AccountResponse>("/accounts/list_accounts");
};
