namespace Fyley.Core.Asp.Models
{
    public class ApiResponse<TData> : ApiResponse
    {
        public TData Data { get; set; }
    }
}