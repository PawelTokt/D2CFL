using System.Threading.Tasks;
using System.Collections.Generic;

namespace D2CFL.Business.League.Contract
{
    public interface IPlayerService
    {
        Task<IList<PlayerDto>> GetList();
        Task<PlayerDto> Get(int id);
        Task Insert(PlayerDto playerDto);
        void Update(PlayerDto playerDto);
        void Delete(PlayerDto playerDto);
    }
}