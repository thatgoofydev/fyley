import { renderHook, act } from "@testing-library/react-hooks";
import fetchMock from "jest-fetch-mock";

import { useApi } from "./useApi";
import { RequestState } from "./types";

interface Request {
  id: number;
}

interface Response {
  id: number;
  name: string;
}

const mockStatusAndBody = (status: number, data: any) => {
  fetchMock.doMockOnce(async () => ({
    status: 200,
    body: JSON.stringify(data)
  }));
};

describe("useApi", function () {
  test("should do fetch with correct parameters", async () => {
    fetchMock.doMockOnce(async request => {
      expect(request.method).toBe("POST");
      expect(request.headers.get("Accept")).toBe("application/json");
      expect(request.headers.get("Content-Type")).toBe("application/json;charset=utf-8");
      expect(await request.text()).toBe(`{"id":123}`);

      return {
        status: 200,
        body: JSON.stringify({ ok: true })
      };
    });

    const { waitForNextUpdate } = renderHook(() =>
      useApi<Response, Request>("/some-api-endpoint", { id: 123 })
    );

    await waitForNextUpdate();
  });

  test("should return 'state = RequestState.Loading' when a loading", async () => {
    fetchMock.doMockOnce(async () => ({ status: 200 }));

    const { result, waitForNextUpdate } = renderHook(() => useApi<Response>("/some-api-endpoint"));

    expect(result.current.state).toBe(RequestState.LOADING);
    await waitForNextUpdate();
    expect(result.current.state).not.toBe(RequestState.LOADING);
  });

  test("should return 'state = RequestState.ERROR' when a http error occurres", async () => {
    fetchMock.doMockOnce(async () => ({ status: 500 }));

    const { result, waitForNextUpdate } = renderHook(() => useApi<Response>("/some-api-endpoint"));

    expect(result.current.state).toBe(RequestState.LOADING);
    await waitForNextUpdate();
    expect(result.current.state).toBe(RequestState.ERROR);
  });

  test("should return 'state = RequestState.ERROR' when an error response was returned", async () => {
    const data = { ok: false, error: "not found" };
    mockStatusAndBody(200, data);

    const { result, waitForNextUpdate } = renderHook(() => useApi<Response>("/some-api-endpoint"));

    expect(result.current.state).toBe(RequestState.LOADING);
    await waitForNextUpdate();
    expect(result.current.state).toBe(RequestState.ERROR);
  });

  test("should return 'state = RequestState.SUCCESS' when request was successful", async () => {
    const data = { ok: true, data: { id: 123, name: "john" } };
    mockStatusAndBody(200, data);

    const { result, waitForNextUpdate } = renderHook(() => useApi<Response>("/some-api-endpoint"));

    expect(result.current.state).toBe(RequestState.LOADING);
    await waitForNextUpdate();
    expect(result.current.state).toBe(RequestState.SUCCESS);
  });

  test("should return correct data", async () => {
    const data = { ok: true, data: { id: 123, name: "john" } };
    mockStatusAndBody(200, data);

    const { result, waitForNextUpdate } = renderHook(() => useApi<Response>("/some-api-endpoint"));
    await waitForNextUpdate();

    expect(result.current.state).toBe(RequestState.SUCCESS);
    expect(result.current.data).toEqual({ id: 123, name: "john" });
  });

  test("should return error value", async () => {
    const data = { ok: false, error: "some error" };
    mockStatusAndBody(200, data);

    const { result, waitForNextUpdate } = renderHook(() => useApi<Response>("/some-api-endpoint"));
    await waitForNextUpdate();

    expect(result.current.state).toBe(RequestState.ERROR);
    expect(result.current.error).toBe("some error");
  });
});
