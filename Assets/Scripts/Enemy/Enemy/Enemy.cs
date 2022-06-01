using System;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Inventories;
using Player;

public class Enemy : MonoBehaviour
{
   [HideInInspector] public Animator anim;
    public Transform Target { get; private set; }
    public float enemyHp;
    public bool isWraith;
    public float attackDamage, attackRange, attackCooldown, runSpeed, aimSpeed, attackReadyTimer;

    public Transform firePoint;
    public BulletControl bullet;
    public float bulletTime; // Attack Range
    public float bulletSpeed;

    public StateMachine StateMachine => GetComponent<StateMachine>();

    public bool hasDied;

    bool run;
    bool attack;
    bool death;
    bool screaming;
    private static readonly int Scream = Animator.StringToHash("Scream");
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    private static readonly int Death1 = Animator.StringToHash("Death");

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
         Debug.unityLogger.logEnabled = false;
#endif
        InitializeStateMachine();
    }


    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(IdleState), new IdleState(this)},
            {typeof(ChaseState), new ChaseState(this)},
            {typeof(AttackState), new AttackState(this)},
            {typeof(DeathState), new DeathState(this)}
        };

        GetComponent<StateMachine>().SetStates(states);
    }

    public void AimToTarget()
    {
        Vector3 targetDirection = Target.position - transform.position;
        float singleStep = aimSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void TakeDamage()
    {
        var damage = Target.gameObject.GetComponent<PlayerStats>().GetStat(Stat.PlayerDamage);
        enemyHp = Mathf.Max(enemyHp - damage, 0);
        Debug.Log(enemyHp);
        AudioManager.Instance.Play("scream");
    }

    public void Attack(float damage)
    {
        SetAttack();
        SetAnimations();
        if (isWraith)
        {
            var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newBullet.speed = bulletSpeed;
            newBullet.range = bulletTime;
            AudioManager.Instance.Play("zombie4");
        }
        else
        {
            AudioManager.Instance.Play("zombie2");
            Debug.Log("Attacking");
            Target.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public bool CheckHealth()
    {
        if (enemyHp <= 0)
        {
            return true;
        }

        return false;
    }

    public void Death()
    {
        AudioManager.Instance.Play("scream");
        gameObject.GetComponent<Collider>().enabled = false;
        SetDeath();
        SetAnimations();
        GetComponent<RandomDropper>().RandomDrop();
        Destroy(this.gameObject, 2f);
        hasDied = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    //Animator Stuff

    public void SetRun()
    {
        screaming = false;
        run = true;
        attack = false;
        death = false;
    }

    public void SetAttack()
    {
        screaming = false;
        run = false;
        attack = true;
        death = false;
    }

    public void SetDeath()
    {
        screaming = false;
        run = false;
        attack = false;
        death = true;
    }

    public void SetScream()
    {
        screaming = true;
        run = false;
        attack = false;
        death = false;
    }

    public void SetAnimations()
    {
        anim.SetBool(Scream, screaming);
        anim.SetBool(Run, run);
        anim.SetBool(Attack1, attack);
        anim.SetBool(Death1, death);
    }
}