using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidbody2D;

    public override BulletDataSO BulletData
    { 
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if(rigidbody2D != null && BulletData != null)
        {
            rigidbody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);

        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy();
        }
        Destroy(gameObject);
    }

    private void HitEnemy()
    {
        Debug.Log("Hitting Enemy");
    }

    private void HitObstacle()
    {
        
    }
}
