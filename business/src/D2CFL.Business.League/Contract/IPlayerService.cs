using System.Collections.Generic;
using System.Threading.Tasks;

namespace D2CFL.Business.League.Contract
{
    public interface IPlayerService
    {
        Task<IList<PlayerDto>> GetList();
        Task<PlayerDto> Get(int id);
        Task Insert(PlayerDto playerDto);
        Task Update(PlayerDto playerDto);
    }
}