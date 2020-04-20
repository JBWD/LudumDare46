using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Singleton()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    private void Awake()
    {
        Singleton();
        //DontDestroyOnLoad(gameObject);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Start_W();    
    }

    // Update is called once per frame
    void Update()
    {
        Update_W();
    }
}
