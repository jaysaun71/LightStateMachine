namespace Lightfsm.Classes
{
    public interface IStateMachineManager<TStateEnum, TPayload>
        where TPayload : class
        where TStateEnum : System.Enum
    {
        void GoToPreviousState();
        void Initialize(TPayload payload);
        void PerformTransition();
        void PerformTransitionTo(TStateEnum state);
        void StartMachine(TPayload payload);
    }
}