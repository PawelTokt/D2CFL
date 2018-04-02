namespace D2CFL.WebSite.Admin.Models
{
    public class PositionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double KillCoefficient { get; set; }
        public double DeathCoefficient { get; set; }
        public double AssistCoefficient { get; set; }
    }
}