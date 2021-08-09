using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidbody2d = null;
    private bool isContacted = false;

    public override BulletDataSO BulletData
    { 
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2d = GetComponent<Rigidbody2D>();
            rigidbody2d.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if(rigidbody2d != null && BulletData != null)
        {
            rigidbody2d.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isContacted) return;
        isContacted = true;

        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);

        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(collision);
        }

        Destroy(gameObject);
    }

    private void HitEnemy(Collider2D collision)
    {
        var knockback = collision.GetComponent<IKnockBack>();
        knockback?.KnockBack(transform.right, BulletData.KnockBackPower, BulletData.KnockBackDelay);

        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * .5f;
        Instantiate(BulletData.ImpactEnemyPrefab,
            collision.transform.position + (Vector3)randomOffset,
            Quaternion.identity);
    }

    private void HitObstacle(Collider2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if(hit.collider != null)
        {
            Instantiate(BulletData.ImpactObstaclePrefab, hit.point, Quaternion.identity);
        }
    }
}
