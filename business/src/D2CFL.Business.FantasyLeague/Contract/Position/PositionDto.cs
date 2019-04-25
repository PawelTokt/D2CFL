using System;

namespace D2CFL.Business.FantasyLeague.Contract.Position
{
    public class PositionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int KillCoefficient { get; set; }
        public int AssistCoefficient { get; set; }
        public int DeathCoefficient { get; set; }
    }
}
