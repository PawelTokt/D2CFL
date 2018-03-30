using System.Threading.Tasks;
using System.Collections.Generic;

namespace D2CFL.Business.League.Contract
{
    public interface IPlayerService
    {
        //IList<PlayerDto> GetList();
        Task<IList<PlayerDto>> GetList();
        Task<PlayerDto> Get();
        Task Insert(PlayerDto playerDto);
        void Update(PlayerDto playerDto);
        void Delete(PlayerDto playerDto);
    }
}