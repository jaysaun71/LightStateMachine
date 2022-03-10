namespace Lightfsm.Classes
{
    public interface IStateMachineManager<TPayload>
    {
        void Initialize(TPayload payload);
        void PerformTransition();
        void StartMachine(TPayload payload);
    }
}