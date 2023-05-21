using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5_6.Entities.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    [Display(Name = "Male")]
    Female = 0,
    [Display(Name = "Female")]
    Male = 1,
    [Display(Name = "Other")]
    Other = 2
}

