import { ApiResponse, IState, RequestState, UseApiResult } from "./types";
import { useEffect, useState } from "react";

function getRequestParameters<TRequest = void>(body?: TRequest): RequestInit {
  return {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=utf-8"
    },
    body: JSON.stringify(body || {})
  };
}

export const useApi = <TData, TRequest = void>(
  url: string,
  requestContent?: TRequest
): UseApiResult<TData> => {
  const [refreshIndex, setRefreshIndex] = useState(0);
  const [state, setState] = useState<IState<TData>>({
    state: RequestState.LOADING,
    error: "",
    response: undefined
  });

  const setPartialState = (partialState: any) => {
    setState({
      ...state,
      ...partialState
    });
  };

  const refresh = () => {
    setRefreshIndex(refreshIndex + 1);
  };

  useEffect(() => {
    let cancelledRequest = false;
    setPartialState({
      state: RequestState.LOADING,
      error: "",
      response: undefined
    });

    const requestParameters = getRequestParameters<TRequest>(requestContent);
    const finalUrl = `https://localhost:5001/bff${url}`;
    fetch(finalUrl, requestParameters)
      .then(async response => {
        const dataResponse = (await response.json()) as ApiResponse<TData>;
        const newState = dataResponse.ok ? RequestState.SUCCESS : RequestState.ERROR;

        setPartialState({
          state: newState,
          response: dataResponse
        });
      })
      .catch(_ => {
        setPartialState({
          state: RequestState.ERROR
        });
      });

    return () => {
      cancelledRequest = true;
    };
  }, [url, refreshIndex]);

  return {
    state: state.state,
    ok: state.response?.ok || false,
    error: state.response?.error || "",
    data: state.response?.data || ({} as TData),
    refresh
  };
};
