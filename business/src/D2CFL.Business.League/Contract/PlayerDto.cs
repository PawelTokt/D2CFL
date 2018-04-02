namespace D2CFL.Business.League.Contract
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Lastname { get; set; }
        public int PositionId { get; set; }
        public string PositionS { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }

    }
}