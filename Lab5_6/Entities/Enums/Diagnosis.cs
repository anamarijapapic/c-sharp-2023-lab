using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5_6.Entities.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Diagnosis
{
    [Display(Name = "A00-B99  Certain infectious and parasitic diseases")]
    A00_B99 = 0,
    [Display(Name = "C00-D48  Neoplasms")]
    C00_D48 = 1,
    [Display(Name = "D50–D89  Diseases of the blood and blood-forming organs and certain disorders involving the immune mechanism")]
    D50_D89 = 2,
    [Display(Name = "E00-E90  Endocrine, nutritional and metabolic diseases")]
    E00_E90 = 3,
    [Display(Name = "F00–F99  Mental and behavioural disorders")]
    F00_F99 = 4,
    [Display(Name = "G00–G99  Diseases of the nervous system")]
    G00_G99 = 5,
    [Display(Name = "H00–H59  Diseases of the eye and adnexa")]
    H00_H59 = 6,
    [Display(Name = "H60–H95  Diseases of the ear and mastoid process")]
    H60_H95 = 7,
    [Display(Name = "I00–I99  Diseases of the circulatory system")]
    I00_I99 = 8,
    [Display(Name = "J00–J99  Diseases of the respiratory system")]
    J00_J99 = 9,
    [Display(Name = "K00–K93  Diseases of the digestive system")]
    K00_K93 = 10,
    [Display(Name = "L00–L99  Diseases of the skin and subcutaneous tissue")]
    L00_L99 = 11,
    [Display(Name = "M00–M99  Diseases of the musculoskeletal system and connective tissue")]
    M00_M99 = 12,
    [Display(Name = "N00–N99  Diseases of the genitourinary system")]
    N00_N99 = 13,
    [Display(Name = "O00–O99  Pregnancy, childbirth and the puerperium")]
    O00_O99 = 14,
    [Display(Name = "P00–P96  Certain conditions originating in the perinatal period")]
    P00_P96 = 15,
    [Display(Name = "Q00–Q99  Congenital malformations, deformations and chromosomal abnormalities")]
    Q00_Q99 = 16,
    [Display(Name = "R00–R99  Symptoms, signs and abnormal clinical and laboratory findings, not elsewhere classified")]
    R00_R99 = 17,
    [Display(Name = "S00–T98  Injury, poisoning and certain other consequences of external causes")]
    S00_T98 = 18,
    [Display(Name = "V01–Y98  External causes of morbidity and mortality")]
    V01_Y98 = 19,
    [Display(Name = "Z00–Z99  Factors influencing health status and contact with health services")]
    Z00_Z99 = 20,
    [Display(Name = "U00–U99  Codes for special purposes")]
    U00_U99 = 21,
}

