using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Domain.Entities.History;
using ProcessSIM.Infrastructure.Data;
using ProcessSIM.Infrastructure.Extensions;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class SimulationHistoryRepository : ISimulationHistoryRepository
    {
        private readonly SimContext _db;

        public SimulationHistoryRepository(SimContext db)
        {
            _db = db;
        }

        public async Task<List<SimulationHistory>> GetAllHistory()
        {
            return await _db.SimulationHistory.Include(x => x.Resources).ThenInclude(x => x.UseHistory)
                .Include(x => x.Procedures).ThenInclude(x => x.RandomEvents).Include(x => x.SimulationName)
                .ToListAsync();
        }

        public async Task<List<SimulationHistory>> GetHistoryByUsername(string username)
        {
            return await _db.SimulationHistory.Include(x => x.Resources).ThenInclude(x => x.UseHistory)
                .Include(x => x.Procedures).ThenInclude(x => x.RandomEvents).Include(x => x.SimulationName)
                .Where(x => x.Username == username).ToListAsync();
        }

        public async Task AddSimulationHistory(SimulationHistory history)
        {
            await _db.SimulationHistory.AddAsync(history);

            await _db.SaveChangesAsync();
        }
    }
}