using ProcessSIM.Domain.Entities.History;
using ProcessSIM.Domain.Simulation;
using ProcessSIM.Domain.Simulation.ViewModels;
using ProcessSIM.Domain.Simulation.ViewModels.Result;

namespace ProcessSIM.Simulation
{
    public interface ISimulationCore
    {
        SimulationHistory SimulationStart(StartSimulationViewModel model);
    }
}