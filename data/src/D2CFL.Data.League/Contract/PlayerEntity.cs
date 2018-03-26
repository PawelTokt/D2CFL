namespace D2CFL.Data.League.Contract
{
    public class PlayerEntity : Entity
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }

        public int? PositionEntityId { get; set; }
        public PositionEntity Position { get; set; }

        public int? TeamEntityId { get; set; }
        public TeamEntity Team { get; set; }
    }
}