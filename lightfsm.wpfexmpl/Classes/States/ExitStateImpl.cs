namespace Lightfsm.Wpfexmpl.Classes.States
{
    using System.Collections.Generic;
    public class ExitStateImpl : StateImplBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitStateImpl"/> class.
        /// </summary>
        public ExitStateImpl()
            : base(new List<ApplicationViewsStateEnum>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitStateImpl"/> class.
        /// </summary>
        /// <param name="allowedStates">Allowed transition states</param>
        public ExitStateImpl(IList<ApplicationViewsStateEnum> allowedStates)
            : base(allowedStates)
        {
        }
    }
}