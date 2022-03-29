namespace Core.Lightfsm.Wpfexmpl.Classes
{

    using System.Collections.Generic;
    using Core.Lightfsm.Interfaces;
    using Core.Lightfsm.Wpfexmpl.Classes;
    using Core.Lightfsm.Wpfexmpl.Classes.States;

    /// <summary>
    /// The states configurator.
    /// </summary>
    public class ViewsStateConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewsStateConfiguration"/> class.
        /// </summary>
        public ViewsStateConfiguration()
        {
        }

        /// <summary>
        /// Gets the exit state enum.
        /// </summary>
        public ApplicationViewsStateEnum StartState => ApplicationViewsStateEnum.HomePageState;

        /// <summary>
        /// The exit state enum.
        /// </summary>
        public ApplicationViewsStateEnum ExitState => ApplicationViewsStateEnum.ExitState;

        /// <summary>
        /// The get configuration.
        /// </summary>
        /// <returns>
        /// The <see cref="IDictionary{TKey,TValue}"/>.
        /// </returns>
        public IDictionary<ApplicationViewsStateEnum, IStateAction<ApplicationViewsStateEnum, IViewStatePayload>> GetConfiguration()
        {
            // TODO: use alias of ApplicationViewStateEnum to clean up ? unreadable code
            return new Dictionary<ApplicationViewsStateEnum, IStateAction<ApplicationViewsStateEnum, IViewStatePayload>>
                       {
                           { ApplicationViewsStateEnum.HomePageState, new HomePageStateImpl(new List<ApplicationViewsStateEnum> { ApplicationViewsStateEnum.SettingsPageState, ApplicationViewsStateEnum.ExitState }) },
                           { ApplicationViewsStateEnum.SettingsPageState, new SettingsPageStateImpl(new List<ApplicationViewsStateEnum> { ApplicationViewsStateEnum.AppPageState, ApplicationViewsStateEnum.ExitState }) },
                           { ApplicationViewsStateEnum.AppPageState, new AppPageStateImpl(new List<ApplicationViewsStateEnum> { ApplicationViewsStateEnum.ExitState }) },
                           { ApplicationViewsStateEnum.ExitState, new ExitStateImpl() },
                       };
        }
    }
}