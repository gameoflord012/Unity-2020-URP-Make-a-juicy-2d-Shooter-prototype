using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    public int Health { get; set; } = 5;
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private bool dead = false;

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (dead) return;

        Health--;
        OnGetHit?.Invoke();
        if(Health <= 0)
        {
            OnDie?.Invoke();
            dead = true;
        }
    }
}