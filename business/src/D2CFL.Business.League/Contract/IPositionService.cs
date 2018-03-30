using System.Threading.Tasks;
using System.Collections.Generic;

namespace D2CFL.Business.League.Contract
{
    public interface IPositionService
    {
        Task<IList<PositionDto>> GetList();
        Task<PositionDto> Get();
        Task Insert(PositionDto playerDto);
        void Update(PositionDto playerDto);
        void Delete(PositionDto playerDto);
    }
}