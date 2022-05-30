using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
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

    public ChaseState(Enemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
        enemy.SetTarget(GameObject.FindWithTag("Player").transform);
    }

    public override void Enter()
    {
        _enemy.SetRun();
        _enemy.SetAnimations();
        nav.speed = _enemy.runSpeed;
    }

    public override Type Tick()
    {
        _enemy.AimToTarget();
        if (_enemy.CheckHealth())
        {
            return typeof(DeathState);
        }
        
        var distance = Vector3.Distance(transform.position, _enemy.Target.transform.position);
        if (distance <= _enemy.attackRange && _enemy.attackReadyTimer <= 0f)
        {
            return typeof(AttackState);
        }

        if (distance <= _enemy.attackRange)
        {
            return typeof(IdleState);
        }
        
        _enemy.attackReadyTimer -= Time.deltaTime;
        nav.destination = _enemy.Target.position;
        
        return null;
    }
    
    public override void Exit()
    {
        Debug.Log("ChaseExit");
    }
}
