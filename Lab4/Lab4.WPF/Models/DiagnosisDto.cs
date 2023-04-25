namespace Lab4.WPF.Models
{
    public class DiagnosisDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Title} {Description}";
        }
    }
}
