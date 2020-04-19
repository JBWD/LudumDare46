using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCS.SoundPlayer;

public partial class Weapon : MonoBehaviour
{
    public enum FireMode
    { 
        OneLane,
        //TwoLanes,
       // ThreeLanes
    }


    public float firerate;
    public GameObject ProjectilePrefab;
    public FireMode fireMode;
    public KeyCode FireKey;
    public AudioClip FireSound;
    public float LaneDistance;


    protected float fireTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        fireTime = 0;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        fireTime += Time.deltaTime;
        if(fireTime > firerate && Input.GetKeyDown(FireKey))
        {
            Fire();
            fireTime = 0;
        }
    }

    public virtual void Fire()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint((Vector2)(Input.mousePosition));


        if (FireSound != null)
            SoundManager.Instance.PlaySound(MixerPlayer.Instantiations, FireSound);
        switch (fireMode)
        {
            case FireMode.OneLane:
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                direction.Normalize();
                GameObject projectile = (GameObject)Instantiate(ProjectilePrefab, myPos, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<Projectile>().ProjectileSpeed;
                projectile.GetComponent<Projectile>().SetDamage(currentDamage);
                projectile.GetComponent<Projectile>().SetTag(gameObject.tag);
                break;
        }
        
    }
}
