using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cC;
    [SerializeField] float speed;
    [SerializeField] float gravityForce;
    [SerializeField] float jumpForce;
    [SerializeField] float sensibility;
    private int isRun;
    private Vector3 gravitySpeed;
    private float cameraAxis;
    // Start is called before the first frame update
    void Start()
    {
        cC = GetComponent<CharacterController>();
        Debug.Log("Con La F Se Activa La Bolita De La Mano, Sirve Para Auyentar A Los Enemigos Pero Al Usarlo Mucho Tiempo \"Explota\" y Con La E Se Enciende Una Linterna");
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        Jump();
        MoveInput();
        Rotate();
    }

    void MoveInput()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.forward, 1f); }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.back, 1f); }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.left, 1f); }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.right, 1f); }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.forward, 1.8f); }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.back, 1.8f); }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.left, 1.8f); }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) { Move(Vector3.right, 1.8f); }
    }

    void Move(Vector3 direction, float speedRun)
    {
        cC.Move(transform.TransformDirection(direction) * speed * Time.deltaTime * speedRun);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cC.isGrounded)
        {
            gravitySpeed.y = Mathf.Sqrt(-jumpForce * -gravityForce);
        }
    }

    void Gravity()
    {
        gravitySpeed.y += -gravityForce * Time.deltaTime;
        cC.Move(gravitySpeed * Time.deltaTime);
    }

    void Rotate()
    {
        cameraAxis += Input.GetAxis("Mouse X") * sensibility;
        Quaternion rotateD = Quaternion.Euler(0f, cameraAxis, 0f);
        transform.localRotation = rotateD; 
    }
}
