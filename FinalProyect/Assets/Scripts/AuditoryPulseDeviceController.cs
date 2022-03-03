using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuditoryPulseDeviceController : MonoBehaviour
{
    private GameObject[] Enemies;
    private bool isFollow = true;
    private int i;
    private int timeUse;
    private bool isLocked;
    [SerializeField] int maxTime;
    [SerializeField] GameObject APD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            timeUse++;
            if (!isLocked)
            {
                FollowFalse();
                isLocked = true;
                APD.SendMessage("ChangeColor", "Green");
            }
            Debug.Log("Time: " + timeUse);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            FollowTrue();
            timeUse = 0;
            isLocked = false;
            APD.SendMessage("ChangeColor", "Blue");
        }

        if (timeUse >= maxTime)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (timeUse == 25)
        {
            APD.SendMessage("ChangeColor", "Red");
        }
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");        
    }

    void FollowFalse()
    {
        i = 0;
        while (i < Enemies.Length)
        {
            Enemies[i].SendMessage("followChange", false);   
            //Debug.Log("Bucle isFollow = true i=" + i);    
            i++;        
        }            
        isFollow = false;
    }

    void FollowTrue()
    {
        i = 0;
        while (i < Enemies.Length)
        {
            Enemies[i].SendMessage("followChange", true);   
            //Debug.Log("Bucle isFollow = false i=" + i);    
            i++;        
        }            
        isFollow = true;
    }
}
