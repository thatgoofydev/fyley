export interface IAccountFormModel {
  name: string;
  description: string;
  accountNumber: string;
  accountNumberType: AccountNumberType;
}

export enum AccountNumberType {
  IBAN = "Iban",
  OTHER = "Other"
}
