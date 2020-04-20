using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BossController : MonoBehaviour
{

    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start_W()
    {
        
    }

    // Update is called once per frame
    void Update_W()
    {
        
    }


    private void OnDestroy()
    {
        GameManager.Instance.PauseGame();
        WinScreen.SetActive(true);
    }
}
