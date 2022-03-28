namespace Core.Lightfsm.Wpfexmpl.Classes.States
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lightfsm.Interfaces;
    using Lightfsm.Wpfexmpl.ViewModels;

    public class SettingsPageStateImpl : StateImplBase, IStateAction<ApplicationViewsStateEnum, IViewStatePayload>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPageStateImpl"/> class.
        /// </summary>
        public SettingsPageStateImpl()
            : base(new List<ApplicationViewsStateEnum>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPageStateImpl"/> class.
        /// </summary>
        /// <param name="allowedStates">Allowed Transition States</param>
        public SettingsPageStateImpl(IList<ApplicationViewsStateEnum> allowedStates)
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
            return ApplicationViewsStateEnum.AppPageState;
        }

        public void PerformOnEnterAction(IViewStatePayload payload)
        {
            payload.CurrentViewModel = new SettingsPageViewModel();
        }
    }
}