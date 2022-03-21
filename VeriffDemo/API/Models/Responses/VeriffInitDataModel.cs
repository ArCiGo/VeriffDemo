using System.Text.Json.Serialization;

namespace VeriffDemo.API.Models
{
    public class VeriffInitDataModel
    {
        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("preselectedDocument")]
        public VeriffPreselectedDocumentModel PreselectedDocument { get; set; }
    }
}
