using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charCont;
    public float playerSpeed;
    public float gravity;
    public float G;
    float yVelocity;
    public float jumpForce;
    bool onLadder;
    public int jumpCount;
    public GameObject feet;
    public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
            RaycastHit rayHit;
            if (Physics.Raycast(feet.transform.position, -transform.up, out rayHit, .3f, ~9))
            {
                jumpCount = 0;

            }
            if (Physics.Raycast(head.transform.position, transform.up, out rayHit, .3f, ~9))
            {
                G = 0;
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            onLadder = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!LevelMovement.Instance.rotating)
        {
            G -= gravity;
            if (G <= -9.8)
            {
                G = -9.8f;
            }

            if (onLadder)
            {
                G = playerSpeed * Input.GetAxis("Vertical");
            }

            Vector3 moveDir = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
            moveDir += new Vector3(0, G * Time.deltaTime, 0);

            charCont.Move(moveDir);
            if (jumpCount < 2)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpCount++;
                    G = jumpForce;
                }
            }
        }
        
    }
}
