using D2CFL.Business.Organization.Contract.Position;

namespace D2CFL.Api.Website.Models.Organization.Position
{
    public class PositionActionModel : IPositionDto
    {
        public string Name { get; set; }
        public int KillCoefficient { get; set; }
        public int AssistCoefficient { get; set; }
        public int DeathCoefficient { get; set; }
    }
}