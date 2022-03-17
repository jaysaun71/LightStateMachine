namespace Lightfsm.Wpfexmpl.Classes.States
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lightfsm.Interfaces;
    using Lightfsm.Wpfexmpl.ViewModels;

    public class HomePageStateImpl : StateImplBase, IStateAction<ApplicationViewsStateEnum, IViewStatePayload>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageStateImpl"/> class.
        /// </summary>
        public HomePageStateImpl()
            : base(new List<ApplicationViewsStateEnum>())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageStateImpl"/> class.
        /// </summary>
        /// <param name="allowedStates">Allowed Transitions States</param>
        public HomePageStateImpl(IList<ApplicationViewsStateEnum> allowedStates) : base(allowedStates)
        {
        }

        public bool CanPerform()
        {
            //TODO: customize it. add some logic maybe delegated
            return true;
        }

        public async Task<ApplicationViewsStateEnum> PerformTransitionAction(IViewStatePayload payload)
        {
            return ApplicationViewsStateEnum.SettingsPageState;
        }

        public void PerformOnEnterAction(IViewStatePayload payload)
        {
            payload.CurrentViewModel = new HomePageViewModel();
        }
    }
}