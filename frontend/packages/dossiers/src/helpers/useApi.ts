import { useEffect, useState } from "react";
import { url } from "inspector";

interface ApiResponse {
  ok: boolean;
  error: string;
}

interface DataApiResponse<Data> extends ApiResponse {
  data: Data;
}

type ApiResponseType<Data> = ApiResponse | DataApiResponse<Data>;

interface TypedFetchResponse<Data = any> extends Response {
  json<P = Data>(): Promise<ApiResponseType<P>>;
}

function myFetch<Data = any>(
  input: RequestInfo,
  init?: RequestInit
): Promise<TypedFetchResponse<Data>> {
  return fetch.apply(window, [input, init]);
}

export const useApi = <Data = any>(url: string, content: any = null) => {
  const [loading, setLoading] = useState<boolean>(true);
  const [data, setData] = useState<Data>();
  const [hasError, setHasError] = useState<boolean>(false);
  const [error, setError] = useState<string | undefined>(undefined);
  const [statusCode, setStatusCode] = useState<number | undefined>(undefined);

  useEffect(() => {
    fetchData();
  }, [url]);

  const fetchData = () => {
    setLoading(true);
    setHasError(false);
    setError(undefined);
    setData(undefined);

    myFetch<Data>(`https://localhost:5001${url}`, {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json;charset=utf-8"
      },
      body: "{}"
    })
      .then(res => {
        setStatusCode(res.status);
        return res.json();
      })
      .then(res => {
        setHasError(!res.ok);
        setError(res.error);

        setData((res as DataApiResponse<Data>).data);
      })
      .catch(error => {
        setError(undefined);
        setHasError(true);
      })
      .finally(() => setLoading(false));

    // fetch<TypedFetchResponse>("url", { method: "POST" });
    //   .then(res => {
    //     setStatusCode(res.status);
    //     return res;
    //   })
    //   .then(res => res.json())
    //   .then(response => {})
    //   .catch(error => {
    //     setError("");
    //     console.error(error);
    //   })
    //   .finally(() => setLoading(false));
  };

  return { loading, data, hasError, error, statusCode };
};
