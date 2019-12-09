namespace LightStateMachine.WpfExample.Classes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LightStateMachine.Interfaces;

    /// <summary>
    /// The Backup files states enum.
    /// </summary>
    public enum BackupFilesStateEnum
    {
        /// <summary>
        /// The check version state.
        /// </summary>
        SettingsState,

        /// <summary>
        /// Transfer to removeable state.
        /// </summary>
        TransferToRemoveableState,

        /// <summary>
        /// The recover previous version state.
        /// </summary>
        TransferToLocationState,

        /// <summary>
        /// The exit state.
        /// </summary>
        ExitState,

        /// <summary>
        /// The null state.
        /// </summary>
        NullState
    }

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
        /// The exit state enum.
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

    public class StateImplBase : IStateAction<BackupFilesStateEnum, object>
    {
        public bool CanPerform()
        {
            throw new System.NotImplementedException();
        }

        public Task<BackupFilesStateEnum> PerformTransitionAction(object payload)
        {
            throw new System.NotImplementedException();
        }

        public void PerformOnEnterAction(object payload)
        {
            throw new System.NotImplementedException();
        }
    }
    public class ExitStateImpl : StateImplBase
    {
    }

    public class PreviousVersionRecoveryStateImpl : StateImplBase
    {
    }

    public class InstallStateImpl : StateImplBase
    {
    }

    public class CheckVersionStateImpl : StateImplBase
    {
    }
}