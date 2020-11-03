using System.Collections.Generic;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Domain.Entities.History;

namespace ProcessSIM.Infrastructure.Repositories
{
    public interface ISimulationHistoryRepository
    {
        Task<List<SimulationHistory>> GetAllHistory();
        Task<List<SimulationHistory>> GetHistoryByUsername(string username);
        Task AddSimulationHistory(SimulationHistory history);
    }
}