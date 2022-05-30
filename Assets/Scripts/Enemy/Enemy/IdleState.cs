using System.Collections;
using System.Collections.Generic;
using Player;
using System;
using UnityEngine;

public class IdleState : BaseState
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

    public IdleState(Enemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        nav.speed = 0f;
        _enemy.SetScream();
        _enemy.SetAnimations();
        AudioManager.Instance.Play("zombie3");
    }

    public override Type Tick()
    {
        _enemy.AimToTarget();
        if (_enemy.CheckHealth())
        {
            return typeof(DeathState);
        }

        var distance = Vector3.Distance(transform.position, _enemy.Target.transform.position);
        if (distance <= _enemy.attackRange && _enemy.attackReadyTimer <= 0)
        {
            return typeof(AttackState);
        }

        if (distance >= _enemy.attackRange)
        {
            return typeof(ChaseState);
        }

        _enemy.attackReadyTimer -= Time.deltaTime;

        return null;
    }

    public override void Exit()
    {
        Debug.Log("IdleExit");
    }
}