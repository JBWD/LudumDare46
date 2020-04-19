using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteOrderer : MonoBehaviour
{

    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sp.sortingOrder = -(int)(transform.position.y * 100);
    }
}
