using EmailServiceApi.Data;
using System.ComponentModel.DataAnnotations;

namespace EmailServiceApi.Models
{
    public class ApiModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [Url]
        public string? RequestUrl { get; set; }

        [Url]
        public string? BaseUrl { get; set; }

        public IEnumerable<ApiParams>? RequiredParams { get; set; }

        public IEnumerable<ApiParams>? OptionalParams { get; set; }

        public ResponseModel ResponseModelType { get; set; }

    }
}
