interface IApiResponse {
  ok: boolean;
  error: string;
}

interface IApiDataResponse<TData> {
  ok: boolean;
  error: string;
  data: TData;
}

export type ApiResponse<TData> = IApiResponse & IApiDataResponse<TData>;

export enum RequestState {
  LOADING = "LOADING",
  SUCCESS = "SUCCESS",
  ERROR = "ERROR"
}

export interface IState<TData> {
  state: RequestState;
  error: string;
  response: ApiResponse<TData> | undefined;
}

interface IResult {
  state: RequestState;
  ok: boolean;
  error: string;
  refresh: () => void;
}

interface IDataResult<TData> extends IResult {
  data: TData;
}

export type UseApiResult<TData> = IResult & IDataResult<TData>;
