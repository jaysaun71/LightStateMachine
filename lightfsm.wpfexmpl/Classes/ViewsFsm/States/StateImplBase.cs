namespace LightStateMachine.WpfExample.Classes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LightStateMachine.Interfaces;

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
}