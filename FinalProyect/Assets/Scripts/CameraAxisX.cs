using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAxisX : MonoBehaviour
{
    private float cameraAxis;
    [SerializeField] float sensibility;
    //[SerializeField] GameObject gO;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        cameraAxis -= Input.GetAxis("Mouse Y") * sensibility;
        Quaternion rotateD = Quaternion.Euler(cameraAxis, 0f, 0f);
        transform.localRotation = rotateD;

        //transform.position = gO.transform.position;
    }
}
