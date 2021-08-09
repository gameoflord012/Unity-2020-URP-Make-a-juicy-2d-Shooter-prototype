using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockBack
{
    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    private AgentMovement agentMovement;

    private bool dead = false;

    public EnemyAttack enemyAttack { get; set; }

    private void Awake()
    {
        if(enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }
        agentMovement = GetComponent<AgentMovement>();
    }

    private void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead) return;

        Health--;
        OnGetHit?.Invoke();
        if (Health <= 0)
        {
            dead = true;
            OnDie?.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    public void PerformAttack()
    {
        if (dead) return;
        enemyAttack.Attack(EnemyData.Damage);
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        agentMovement.KnockBack(direction, power, duration);
    }
}
