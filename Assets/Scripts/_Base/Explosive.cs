using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Projectile
{

    public float radius = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    CCS.SoundPlayer.SoundManager.Instance.PlaySoundCombined(CCS.SoundPlayer.MixerPlayer.Explosions, destructionSound, Random.Range(.6f, 1));
                }
                RaycastHit2D[] circleHit = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);
                for (int i = 0; i < circleHit.Length; i ++)
                {
                    if (circleHit[i].collider.gameObject.GetComponent<EnemyController>())
                    {
                        circleHit[i].collider.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
