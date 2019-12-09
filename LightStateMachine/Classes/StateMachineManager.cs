namespace LightStateMachine.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using LightStateMachine.Interfaces;

    /// <summary>
    /// The state manager.
    /// </summary>
    /// <typeparam name="TStateEnum">
    /// Enum type with all possible states.
    /// </typeparam>
    /// <typeparam name="TPayload">
    /// TPayload is pass through all entered states.
    /// </typeparam>
    public class StateMachineManager<TStateEnum, TPayload>
        where TPayload : class
        where TStateEnum : System.Enum
    {
        /// <summary>
        /// The states array.
        /// </summary>
        private readonly Array statesArray;

        /// <summary>
        /// The states configuration dictionary.
        /// </summary>
        private readonly IDictionary<TStateEnum, IStateAction<TStateEnum, TPayload>> statesConfigurationDictionary;

        /// <summary>
        /// The counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateMachineManager{TStateEnum,TPayload}"/> class.
        /// </summary>
        /// <param name="configurationDictionary">
        /// The configuration dictionary.
        /// </param>
        /// <param name="startState">
        /// The start state.
        /// </param>
        /// <param name="exitState">
        /// The exit state.
        /// </param>
        /// <param name="nullState">
        /// The null State.
        /// </param>
        /// <param name="transitionLimit">
        /// The transition limit.
        /// </param>
        public StateMachineManager(
            IDictionary<TStateEnum, IStateAction<TStateEnum, TPayload>> configurationDictionary,
            TStateEnum startState,
            TStateEnum exitState,
            TStateEnum nullState,
            int? transitionLimit = null)
        {
            if (!typeof(TStateEnum).IsEnum)
            {
                throw new ArgumentException($"{nameof(TStateEnum)} must be an enum type.");
            }

            this.statesConfigurationDictionary = configurationDictionary;
            this.StartState = startState;
            this.ExitState = exitState;
            this.NullState = nullState;
            this.TransitionsLimit = transitionLimit ?? 800;

            this.PreviousState = this.NullState;

            this.statesArray = Enum.GetValues(startState.GetType());
        }

        /// <summary>
        /// Gets or sets the transitions limit.
        /// </summary>
        /// <remarks>
        /// Added to avoid infinite recursion.
        /// </remarks>
        public int TransitionsLimit { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        public TPayload Payload { get; set; }

        /// <summary>
        /// Gets the start state.
        /// </summary>
        private TStateEnum StartState { get; }

        /// <summary>
        /// Gets the exit state.
        /// </summary>
        private TStateEnum ExitState { get; }

        /// <summary>
        /// Gets or sets the previous step.
        /// </summary>
        private TStateEnum PreviousState { get; set; }

        /// <summary>
        /// Gets or sets the current step.
        /// </summary>
        private TStateEnum CurrentState { get; set; }

        /// <summary>
        /// Gets the null state.
        /// </summary>
        private TStateEnum NullState { get; }

        /// <summary>
        /// The start machine.
        /// </summary>
        /// <param name="payload">
        /// The payload.
        /// </param>
        public void StartMachine(TPayload payload)
        {
            this.counter = 0;
            this.Payload = payload;
            this.StartTransitionMachine(this.StartState);
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="payload">
        /// The payload.
        /// </param>
        public void Initialize(TPayload payload)
        {
            this.Payload = payload;
            this.statesConfigurationDictionary[this.StartState].PerformOnEnterAction(this.Payload);
            this.CurrentState = this.StartState;
        }

        /// <summary>
        /// The can go to previous state.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>
        /// </returns>`
        public bool CanGoToPreviousState()
        {
            return !this.PreviousState.Equals(this.NullState);
        }

        /// <summary>
        /// The go to previous state.
        /// </summary>
        public void GoToPreviousState()
        {
            this.statesConfigurationDictionary[this.PreviousState].PerformOnEnterAction(this.Payload);
            this.CurrentState = this.PreviousState;
            this.PreviousState = this.NullState;
        }

        /// <summary>
        /// The perform transition.
        /// </summary>
        public void PerformTransition()
        {
            int i = ((IConvertible) this.CurrentState).ToInt32(CultureInfo.InvariantCulture);

            this.PreviousState = this.CurrentState;

            // getting next step as .Result
            this.CurrentState = this.statesConfigurationDictionary[this.CurrentState].PerformTransitionAction(this.Payload).Result;
            this.statesConfigurationDictionary[this.CurrentState].PerformOnEnterAction(this.Payload);
        }

        /// <summary>
        /// The start transition machine.
        /// </summary>
        /// <param name="goToState">
        /// The go to state.
        /// </param>
        private void StartTransitionMachine(TStateEnum goToState)
        {
            try
            {
                // set up cursor
                this.CurrentState = goToState;

                while (!this.ExitState.Equals(this.CurrentState) || this.TransitionsLimit >= this.counter)
                {
                    this.PreviousState = this.CurrentState;

                    // Perform Step logic
                    this.CurrentState = this.statesConfigurationDictionary[this.CurrentState].PerformTransitionAction(this.Payload).Result;
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                this.CurrentState = this.ExitState;
            }
        }
    }
}