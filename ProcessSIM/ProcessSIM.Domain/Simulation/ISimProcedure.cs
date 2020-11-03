namespace ProcessSIM.Domain.Simulation
{
    public interface ISimProcedure
    {
        void UpdateState(int currentTime, int step);
    }
}