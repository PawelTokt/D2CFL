using System;

namespace D2CFL.Api.Website.Models.FantasyLeague.Position
{
    public class PositionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int KillCoefficient { get; set; }
        public int AssistCoefficient { get; set; }
        public int DeathCoefficient { get; set; }
    }
}
