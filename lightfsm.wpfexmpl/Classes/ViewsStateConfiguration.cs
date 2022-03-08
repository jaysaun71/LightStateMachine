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
        public BackupFilesStateEnum StartState => BackupFilesStateEnum.SettingsState;

        /// <summary>
        /// The exit state enum.
        /// </summary>
        public BackupFilesStateEnum ExitState => BackupFilesStateEnum.ExitState;

        /// <summary>
        /// The get configuration.
        /// </summary>
        /// <returns>
        /// The <see cref="IDictionary"/>.
        /// </returns>
        public IDictionary<BackupFilesStateEnum, IStateAction<BackupFilesStateEnum, object>> GetConfiguration()
        {
            return new Dictionary<BackupFilesStateEnum, IStateAction<BackupFilesStateEnum, object>>
                       {
                           { BackupFilesStateEnum.SettingsState, new CheckVersionStateImpl() },
                           { BackupFilesStateEnum.TransferToLocationState, new InstallStateImpl() },
                           { BackupFilesStateEnum.TransferToRemoveableState, new PreviousVersionRecoveryStateImpl() },
                           { BackupFilesStateEnum.ExitState, new ExitStateImpl() },
                       };
        }
    }
}