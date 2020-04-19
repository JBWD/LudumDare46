using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public partial class Projectile : MonoBehaviour
{


    private Rigidbody2D _rb;
    public float ProjectileSpeed = 1;
    public float damage = 1;
    public string parentTag = "";
    public AudioClip destructionSound;
    public GameObject destructionPrefab;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetTag(string tag)
    {
        parentTag = tag;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (parentTag != collision.gameObject.tag)
        {
            if (collision.tag == "Player" || collision.tag == "Turtle" || collision.tag == "Enemy")
            {
                GameObject obj = Instantiate(destructionPrefab, transform.position, Quaternion.identity);
                Destroy(obj, 2);
                if (destructionSound != null)
                {
                    CCS.SoundPlayer.SoundManager.Instance.PlaySound(CCS.SoundPlayer.MixerPlayer.Explosions, destructionSound);
                }
                Destroy(gameObject);
            }
        }
    }
}
