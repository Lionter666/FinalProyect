using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] GameObject Flashlight;
    [SerializeField] AudioClip flashOn;
    [SerializeField] AudioClip flashOff;
    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isActive)
        {
            Flashlight.SetActive(true);
            isActive = true;
            aS.clip = flashOn;
            aS.Play();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            Flashlight.SetActive(false);
            isActive = false;
            aS.clip = flashOff;
            aS.Play();
        }
    }
}
