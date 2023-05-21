using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5_6.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Insurance
    {
        [Display(Name = "Basic")]
        Basic = 0,
        [Display(Name = "Supplementary")]
        Supplementary = 1,
        [Display(Name = "Uninsured")]
        Uninsured = 2
    }
}
