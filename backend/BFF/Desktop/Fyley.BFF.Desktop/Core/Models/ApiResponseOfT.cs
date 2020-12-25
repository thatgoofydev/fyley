namespace Fyley.BFF.Desktop.Core.Models
{
    public class ApiResponse<TData> : ApiResponse
    {
        public TData Data { get; set; }
    }
}