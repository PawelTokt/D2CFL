namespace D2CFL.Business.Organization.Contract.Position
{
    public interface IPositionDto
    {
        string Name { get; set; }
        int KillCoefficient { get; set; }
        int AssistCoefficient { get; set; }
        int DeathCoefficient { get; set; }
    }
}