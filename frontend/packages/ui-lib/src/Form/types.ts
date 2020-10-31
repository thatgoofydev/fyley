export interface FormValues<T = any> {
  [field: string]: T;
}

export interface IFormState {
  values: FormValues;
  errors: FormValues;
  focused: FormValues<boolean>;
  touched: FormValues<boolean>;
}

export interface IFieldState {
  value: any;
  error: any;
  focused: boolean;
  touched: boolean;
}
