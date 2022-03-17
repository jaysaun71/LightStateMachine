namespace Lightfsm.Wpfexmpl.Classes.States
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lightfsm.Interfaces;
    using Lightfsm.Wpfexmpl.ViewModels;

    public class AppPageStateImpl : StateImplBase, IStateAction<ApplicationViewsStateEnum, IViewStatePayload>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppPageStateImpl"/> class.
        /// </summary>
        public AppPageStateImpl()
            : base(new List<ApplicationViewsStateEnum>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppPageStateImpl"/> class.
        /// </summary>
        /// <param name="allowedStates"></param>
        public AppPageStateImpl(IList<ApplicationViewsStateEnum> allowedStates)
            : base(allowedStates)
        {
        }

        public bool CanPerform()
        {
            //TODO: customize it. add some logic maybe delegated
            return true;
        }

        public async Task<ApplicationViewsStateEnum> PerformTransitionAction(IViewStatePayload payload)
        {
            payload.CurrentViewModel = null;
            return ApplicationViewsStateEnum.ExitState;
        }

        public void PerformOnEnterAction(IViewStatePayload payload)
        {
            payload.CurrentViewModel = new AppViewModel();
        }
    }
}