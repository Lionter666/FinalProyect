using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstEnemyController : MonoBehaviour
{
    private GameObject player;
    private GameObject[] EnemyChildren;
    private int i;
    [SerializeField] float speed = 1f;
    [SerializeField] bool isFollow;
    // Start is called before the first frame update
    void Start()
    {
        EnemyChildren = GameObject.FindGameObjectsWithTag("EnemyModel");
    }

    void Awake() 
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {       
        if (isFollow)
        {
            FollowPlayer();
        }
        else
        {
            NotFollowPlayer();
        }
    }

    void FollowPlayer()
    {
        transform.LookAt(player.transform);
        i = 0;
        while (i < EnemyChildren.Length)
        {
            EnemyChildren[i].transform.localRotation = new Quaternion(0f, 0f, 0f, 0);
            i++;
        }        
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void NotFollowPlayer()
    {
        transform.LookAt(player.transform);
        i = 0;
        while (i < EnemyChildren.Length)
        {
            EnemyChildren[i].transform.localRotation = new Quaternion(0f, 180f, 0f, 0);
            i++;
        }   
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
    }

    void followChange(bool changefollow)
    {
        isFollow = changefollow;
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
