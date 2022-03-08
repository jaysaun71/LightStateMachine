namespace Lightfsm.Wpfexmpl.Classes.States
{
    using System.Threading.Tasks;
    using Lightfsm.Interfaces;

    public class StateImplBase : IStateAction<ApplicationViewsStateEnum, object>
    {
        public bool CanPerform()
        {
            throw new System.NotImplementedException();
        }

        public Task<ApplicationViewsStateEnum> PerformTransitionAction(object payload)
        {
            throw new System.NotImplementedException();
        }

        public void PerformOnEnterAction(object payload)
        {
            throw new System.NotImplementedException();
        }
    }
}