namespace Lightfsm.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The StateAction interface.
    /// </summary>
    /// Declaration of transition's action between State <typeparam name="TStateEnum" /> to other State.
    /// <typeparam name="TStateEnum">
    /// Enum type with all possible states.
    /// </typeparam>
    /// <typeparam name="TPayload">
    /// Object passed through all transitions.
    /// </typeparam>
    public interface IStateAction<TStateEnum, in TPayload>
        where TStateEnum : System.Enum
    {
        IList<TStateEnum> AllowedStateTransition { get; }

        /// <summary>
        /// The can perform.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// CanPerform is loosely coupled with PerformTransitionAction. Designed to check if Action can be Performed or Not.
        /// </returns>
        bool CanPerform();

        /// <summary>
        /// The perform action.
        /// </summary>
        /// <param name="payload">
        /// The payload.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TStateEnum> PerformTransitionAction(TPayload payload);

        /// <summary>
        /// The set state.
        /// </summary>
        /// <param name="payload">
        /// The payload.
        /// </param>
        void PerformOnEnterAction(TPayload payload);
    }
}