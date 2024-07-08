namespace API.Models.Dto.Request
{
    public class EtapeDto
    {
        public string? Nometape { get; set; }

        public double? Longueur { get; set; }

        public int? Nombrecoureur { get; set; }

        public int? Rang { get; set; }

        public DateOnly? Datedepart { get; set; }

        public TimeOnly? Heuredepart { get; set; }
    }
}
