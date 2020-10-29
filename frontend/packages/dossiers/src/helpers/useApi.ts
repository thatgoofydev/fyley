import { useEffect, useState } from "react";

interface ApiResponse<TData> {
  ok: boolean;
  error: string;
  data: TData;
}

export interface ApiResult<TData = null> {
  loading: boolean;
  hasError: boolean;
  statusCode: number;
  data: TData | undefined;
  error: any;
  refresh: () => void;
}

export const useApi = <TData = any>(
  url: string,
  content: any = {}
): ApiResult<TData> => {
  const [loading, setLoading] = useState(true);
  const [hasError, setHasError] = useState(false);
  const [statusCode, setStatusCode] = useState();
  const [response, setResponse] = useState<ApiResponse<TData>>();
  const [refreshIndex, setRefreshIndex] = useState(0);

  const refresh = () => {
    setRefreshIndex(refreshIndex + 1);
  };

  useEffect(() => {
    let cancelled = false;
    setLoading(true);
    setHasError(false);
    setResponse(undefined);

    let initRequest: RequestInit = {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json;charset=utf-8"
      },
      body: JSON.stringify(content)
    };
    fetch(`https://localhost:5001${url}`, initRequest)
      .then(res => {
        setStatusCode(res.status);
        return res.json() as Promise<ApiResponse<TData>>;
      })
      .then(response => setResponse(response))
      .catch(error => {
        setHasError(true);
        console.error(error);
      })
      .finally(() => setLoading(false));

    return () => {
      cancelled = true;
    };
  }, [url, refreshIndex]);

  return {
    loading,
    hasError,
    statusCode,
    data: response?.data,
    error: response?.error || null,
    refresh
  };
};
