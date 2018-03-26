using System.Collections.Generic;

namespace D2CFL.Business.League.Contract
{
    public interface IPlayerSerivice
    {
        IList<PlayerDto> GetList();
    }
}