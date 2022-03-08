namespace Lightfsm.Wpfexmpl.Classes
{
    using Lightfsm.Interfaces;
    using Lightfsm.Wpfexmpl.Classes.States;
    using System.Collections.Generic;

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
        /// The <see cref="IDictionary"/>.
        /// </returns>
        public IDictionary<ApplicationViewsStateEnum, IStateAction<ApplicationViewsStateEnum, object>> GetConfiguration()
        {
            return new Dictionary<ApplicationViewsStateEnum, IStateAction<ApplicationViewsStateEnum, object>>
                       {
                           { ApplicationViewsStateEnum.HomePageState, new HomePageState() },
                           { ApplicationViewsStateEnum.SettingsPageState, new SettingsPageState() },
                           { ApplicationViewsStateEnum.AppPageState, new AppPageStateImpl() },
                           { ApplicationViewsStateEnum.ExitState, new ExitStateImpl() },
                       };
        }
    }
}