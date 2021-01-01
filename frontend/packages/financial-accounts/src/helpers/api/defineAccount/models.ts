export interface AccountFormViewModel {
  name: string;
  description: string;
  accountNumber: AccountNumber;
}

export interface AccountNumber {
  value: string;
  type: AccountNumberType;
}

export enum AccountNumberType {
  Iban = "Iban",
  Other = "Other"
}
