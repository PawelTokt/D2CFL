using System.Collections.Generic;

namespace D2CFL.Business.League.Contract
{
    public interface IPlayerService
    {
        IList<PlayerDto> GetList();
        PlayerDto Get(int id);
        void Insert(PlayerDto playerDto);
        void Update(PlayerDto playerDto);
        void Delete(PlayerDto playerDto);
    }
}