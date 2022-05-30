using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    public BaseState(GameObject gameObject)
    {
        this.transform = gameObject.transform;
        this.nav = gameObject.GetComponent<NavMeshAgent>();
    }
   
    protected Transform transform;
    protected NavMeshAgent nav;

    public abstract void Enter();
    public abstract Type Tick();
    public abstract void Exit();
}
