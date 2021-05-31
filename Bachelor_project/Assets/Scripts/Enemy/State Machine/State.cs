using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State:Entity
{
    protected FinateStateMachine stateMachine;
    protected Entity entity;

    protected string animBoolName;

    protected float startTime;

    public State(Entity entity, FinateStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
         
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        DoChecks();

    }
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);

    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        DoChecks();

    }
    public virtual void DoChecks()
    {

    }

}
