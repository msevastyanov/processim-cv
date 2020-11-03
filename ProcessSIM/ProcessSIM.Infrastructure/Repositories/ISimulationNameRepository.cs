using System.Threading.Tasks;
using ProcessSIM.Domain.Entities.History;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface ISimulationNameRepository
    {
        Task<SimulationName> FindSimulationNameByUsername(string simName, string username);
        Task AddSimulationName(SimulationName simName);
    }
}