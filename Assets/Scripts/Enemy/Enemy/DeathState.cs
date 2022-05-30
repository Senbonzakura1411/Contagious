using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class DeathState : BaseState
{
    private Enemy _enemy;

    void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = false;
#else
     Debug.unityLogger.logEnabled = false;
#endif
    }

    public DeathState(Enemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        nav.isStopped = true;
        _enemy.Death();
    }

    public override Type Tick()
    {
        Debug.Log("Morido");
        return null;
    }

    public override void Exit()
    {
        Debug.Log("DeathExit");
    }
}
