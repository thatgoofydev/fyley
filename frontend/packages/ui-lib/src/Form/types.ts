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

export interface IFormState {
  values: FormValues;
  errors: FormValues;
  focused: FormValues<boolean>;
  touched: FormValues<boolean>;
  submitStatus: SubmitStatus;
}

export interface IFieldState {
  value: any;
  error: any;
  focused: boolean;
  touched: boolean;
}

export interface IFormContext {
  state: IFormState;
  actions: FormActions;
  getFieldState: (name: string) => IFieldState;
  setFieldValue: (name: string, values: any) => void;
  onFieldFocus: (name: string) => void;
  onFieldBlur: (name: string) => void;
}
