namespace Core.Lightfsm.Classes
{
    using System;
    using System.Collections.Generic;
    using Core.Lightfsm.Interfaces;

    /// <summary>
    /// The state manager.
    /// </summary>
    /// <typeparam name="TStateEnum">
    /// Enum type with all possible states.
    /// </typeparam>
    /// <typeparam name="TPayload">
    /// TPayload is pass through all entered states.
    /// </typeparam>
    public class StateMachineManager<TStateEnum, TPayload> : IStateMachineManager<TStateEnum, TPayload>
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
        /// The counter is limit of transitions. 
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

            //TODO: add status of fsm so it can be checked if machine is running or not before any transition calls.
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
            this.Initialize(payload);
            this.StartTransitionMachine();
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
            this.CurrentState = this.StartState;
            this.statesConfigurationDictionary[this.StartState].PerformOnEnterAction(this.Payload);
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
            //TODO: improve implementation
            this.statesConfigurationDictionary[this.PreviousState].PerformOnEnterAction(this.Payload);
            this.CurrentState = this.PreviousState;

            // TODO: that implementation is simplific, null state is first previous state or unexpected state of machine(define it nicely)
            // implmentation of linked list or memento pattern?
            this.PreviousState = this.NullState;
        }

        /// <summary>
        /// The perform transition when consumer decide on performing transition.
        /// </summary>
        public void PerformTransition()
        {
            // int i = ((IConvertible) this.CurrentState).ToInt32(CultureInfo.InvariantCulture);

            this.PreviousState = this.CurrentState;

            // getting next step as .Result, can return null
            this.CurrentState = this.statesConfigurationDictionary[this.CurrentState].PerformTransitionAction(this.Payload).Result;
            this.statesConfigurationDictionary[this.CurrentState].PerformOnEnterAction(this.Payload);
        }

        public void PerformTransitionTo(TStateEnum state)
        {
            // TODO: machine knows what the states are allowed, but does not know what transition action will result in(which state)
            // current implementation supports to get a result of new state but it does not stop transition action.
            // in PerformTransitionAction the action should (consumer code) ,but not the transition itself
            if (this.CurrentState.Equals(state)) return;
            if (this.statesConfigurationDictionary[this.CurrentState].AllowedStateTransition.Contains(state))
            {
                this.PerformTransition();
            }
        }

        /// <summary>
        /// The start transition machine for the automatic (non user interaction) fsm.
        /// </summary>
        /// <param name="goToState">
        /// The go to state.
        /// </param>
        /// <remarks>ie. update installer</remarks>
        private void StartTransitionMachine()
        {
            try
            {
                // start automatic transitions
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
                // it's called even when exception happens, still we should log the currentstate for diagnostics(catch or finally?)
                this.CurrentState = this.ExitState;
            }
        }
    }
}