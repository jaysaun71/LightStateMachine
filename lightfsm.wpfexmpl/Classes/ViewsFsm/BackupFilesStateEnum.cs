namespace LightStateMachine.WpfExample.Classes
{
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
}