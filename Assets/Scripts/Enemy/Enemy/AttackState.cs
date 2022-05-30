using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class AttackState : BaseState
{
    private Enemy _enemy;
    private float attackAnimCooldown;

    void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = false;
#else
     Debug.unityLogger.logEnabled = false;
#endif
    }

    public AttackState(Enemy enemy) : base(enemy.gameObject)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        nav.speed = 0f;
        if (_enemy.attackReadyTimer <= 0)
        {
            Debug.Log("Attacked");
            _enemy.Attack(_enemy.attackDamage);
            _enemy.attackReadyTimer = _enemy.attackCooldown;
            attackAnimCooldown = 2.5f;
        }
    }

    public override Type Tick()
    {
        _enemy.AimToTarget();
        if (_enemy.CheckHealth())
            return typeof(DeathState);
        
        if (Vector3.Distance(transform.position, _enemy.Target.transform.position) >= _enemy.attackRange)
        {
            return typeof(ChaseState);
        }

        if (_enemy.attackReadyTimer > 0 && attackAnimCooldown <= 0)
        {
            return typeof(IdleState);
        } 
        
        attackAnimCooldown -= Time.deltaTime;
        return null;
    }

    public override void Exit()
    {
        Debug.Log("AttackExit");
    }
}