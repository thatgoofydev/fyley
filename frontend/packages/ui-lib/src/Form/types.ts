export interface FormValues<T = any> {
  [field: string]: T;
}

export interface FormActions {
  displaySuccess: () => Promise<void>;
  displayError: () => Promise<void>;
}

export enum SubmitStatus {
  IDLE,
  SUBMITTING,
  SUCCESS,
  ERROR
}

export interface IFormState<T> {
  values: T;
  errors: FormValues<string>;
  focused: FormValues<boolean>;
  touched: FormValues<boolean>;
  submitStatus: SubmitStatus;
}

export interface IFieldState {
  value: any | undefined;
  error: string;
  focused: boolean;
  touched: boolean;
}

export interface IFormContext<T> {
  state: IFormState<T>;
  actions: FormActions;
  getFieldState: (name: string) => IFieldState;
  setFieldValue: (name: string, values: any) => void;
  onFieldFocus: (name: string) => void;
  onFieldBlur: (name: string) => void;
}
