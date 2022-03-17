namespace Lightfsm.Wpfexmpl.Classes.States
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lightfsm.Interfaces;
    using Lightfsm.Wpfexmpl.ViewModels;

    public abstract class StateImplBase : IStateAction<ApplicationViewsStateEnum, IViewStatePayload>
    {
        public IList<ApplicationViewsStateEnum> AllowedStateTransition { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateImplBase"/> class.
        /// </summary>
        /// <param name="allowedStates">allowed transition states</param>
        public StateImplBase(IList<ApplicationViewsStateEnum> allowedStates)
        {
            this.AllowedStateTransition = allowedStates;
        }

        public bool CanPerform()
        {
            // TODO: customize it. add some logic maybe delegated
            return true;
        }

        public async Task<ApplicationViewsStateEnum> PerformTransitionAction(IViewStatePayload payload)
        {
            return ApplicationViewsStateEnum.NullState;
        }

        public void PerformOnEnterAction(IViewStatePayload payload)
        {
            // TODO: implement
        }
    }
}