using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Domain.Entities.History;
using ProcessSIM.Infrastructure.Data;

namespace ProcessSIM.Infrastructure.Repositories
{
    public class SimulationNameRepository : ISimulationNameRepository
    {
        private readonly SimContext _db;

        public SimulationNameRepository(SimContext db)
        {
            _db = db;
        }
        
        public async Task<SimulationName> FindSimulationNameByUsername(string simName, string username)
        {
            return await _db.SimulationName
                .SingleOrDefaultAsync(x => x.Name == simName && x.Username == username);
        }

        public async Task AddSimulationName(SimulationName simName)
        {
            await _db.SimulationName.AddAsync(simName);

            await _db.SaveChangesAsync();
        }
    }
}