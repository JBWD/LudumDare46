using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCS.SoundPlayer;

public partial class Weapon : MonoBehaviour
{
    public enum FireMode
    { 
        OneLane,
        TwoLanes,
        ThreeLanes
    }


    public float firerate;
    public GameObject ProjectilePrefab;
    public FireMode fireMode;
    public KeyCode FireKey;
    public AudioClip FireSound;
    public float LaneDistance;


    private float fireTime = 0;
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
        if(FireSound != null)
            SoundManager.Instance.PlaySound(MixerPlayer.Instantiations, FireSound);
        switch (fireMode)
        {
            case FireMode.OneLane:
                Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                break;
            case FireMode.TwoLanes:
                Instantiate(ProjectilePrefab, transform.position + new Vector3(0, LaneDistance), Quaternion.identity);
                Instantiate(ProjectilePrefab, transform.position + new Vector3(0, -LaneDistance), Quaternion.identity);
                break;
            case FireMode.ThreeLanes:
                Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                Instantiate(ProjectilePrefab, transform.position + new Vector3(0, LaneDistance), Quaternion.identity);
                Instantiate(ProjectilePrefab, transform.position + new Vector3(0, -LaneDistance), Quaternion.identity);
                break;
            
        }
        
    }
}
