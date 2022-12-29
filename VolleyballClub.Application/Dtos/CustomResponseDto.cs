using System.Text.Json.Serialization;

namespace VolleyballClub.Application.Dtos
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseDto<T> Success(int statucCode, T data)
        {
            return new CustomResponseDto<T>() { StatusCode = statucCode, Data = data };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T>() { StatusCode = statusCode, Errors = errors };
        }
    }
}
