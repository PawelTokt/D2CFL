using System.Threading.Tasks;
using System.Collections.Generic;

namespace D2CFL.Business.League.Contract
{
    public interface ITeamService
    {
        Task<IList<TeamDto>> GetList();
        Task<TeamDto> Get(int id);
        Task Insert(TeamDto playerDto);
        void Update(TeamDto playerDto);
        void Delete(TeamDto playerDto);
    }
}