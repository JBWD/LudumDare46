using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public partial class EnemyWeapon
{

    public Transform target;


    public override void Update()
    {
        fireTime += Time.deltaTime;
        if (target != null && firerate < fireTime && firerate > 0)
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if(FireSound != null)
        {
            CCS.SoundPlayer.SoundManager.Instance.PlaySound(CCS.SoundPlayer.MixerPlayer.Instantiations, FireSound);
        }
        Vector2 target = this.target.position;

        switch (fireMode)
        {
            case FireMode.OneLane:
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
                Vector2 direction = target - myPos;
                direction.Normalize();
                GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, myPos, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<Projectile>().ProjectileSpeed;
                projectile.GetComponent<Projectile>().SetDamage(currentDamage);
                projectile.GetComponent<Projectile>().SetTag(gameObject.tag);
                break;
        }
        fireTime = 0;
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void RemoveTarget()
    {
        target = null;
    }


}
