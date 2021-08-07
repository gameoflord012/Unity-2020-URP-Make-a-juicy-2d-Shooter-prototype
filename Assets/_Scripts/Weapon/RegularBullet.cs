using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet
{
    protected Rigidbody2D rigidbody2d = null;

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

    }

    private void HitObstacle()
    {
        
    }
}
