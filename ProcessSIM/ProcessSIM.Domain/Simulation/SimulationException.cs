using System;

namespace ProcessSIM.Domain.Simulation
{
    public class SimulationException : Exception
    {
        public SimulationException()
        {
        }

        public SimulationException(string message)
            : base(message)
        {
        }
    }
}