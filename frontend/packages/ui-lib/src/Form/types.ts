export type FormValues<T, P> = {
  [key in keyof T]?: P;
}

export type FormBooleans<T> = FormValues<T, boolean>;
export type FormErrors<T> = FormValues<T, string>;

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
  errors: FormErrors<T>;
  focused: FormBooleans<T>;
  touched: FormBooleans<T>;
  submitStatus: SubmitStatus;
}

export interface IFieldState {
  value: any | undefined;
  error: string | undefined;
  focused: boolean;
  touched: boolean;
}

export interface IFormContext<T> {
  state: IFormState<T>;
  actions: FormActions;
  getFieldState: (name: keyof T) => IFieldState;
  setFieldValue: (name: keyof T, values: any) => void;
  onFieldFocus: (name: keyof T) => void;
  onFieldBlur: (name: keyof T) => void;
}
