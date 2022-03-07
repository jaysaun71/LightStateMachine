using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

//TODO: Scaffold for implementation with the events. add pubsub pattern. 
public class Transition
{
    public State From;
    public State To;

    public List<TransitionEvent> Trigger; 
    public Task<bool> Guard;
    public int x = 10; 

    public Action OnEnter;
    public Action OnLeave;
}

//State
//    PreAction
//    Transition<StateToGo,PreTransition,Guard,PostTransition>
//    PostAction

// Connect -> Connecting (state where logic connects ) result trigger go to other state
// As Long as transition/operation/DO logic is on going -> state machine is in transition or in state? 
// It is definitely not in new state. New state can be recognized after transition ... result of transition?
// ie. triggered DoConnect but did not reach DB intention was to go to Connected but it can go to other states...
// So fact of triggering transition may occur with different result -> different state 
// WHY ? external factors ... Is it only faulty cases ? 

public class TransitionEvent { }

public class State
{
    public List<Transition> Transitions;
    public Action OnEnter;
    public Action OnLeave;
}
