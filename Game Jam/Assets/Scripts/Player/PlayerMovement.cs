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
    public GameObject playerModel;
    public Animator anim;

    #region Animations
    public AnimationClip walking;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>();
        AnimatorOverrideController AOC = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = AOC;
        AOC["Walking"] = walking;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
            RaycastHit rayHit;
            if (Physics.Raycast(feet.transform.position, -transform.up, out rayHit, .2f, 1 << LayerMask.NameToLayer("Ground")))
            {
                jumpCount = 0;

            }
            if (Physics.Raycast(head.transform.position, transform.up, out rayHit, .3f, 1 << LayerMask.NameToLayer("Ground")))
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

            if (Input.GetAxis("Horizontal") != 0)
            {
                RaycastHit rayHit;
                if (Physics.Raycast(feet.transform.position, -transform.up, out rayHit, .3f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    anim.SetBool("Walking", true);
                }
                
            } else
            {
                anim.SetBool("Walking", false);

            }

            if (jumpCount < 2)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    AudioManager.Instance.PlayClip("Jump_1");
                    jumpCount++;
                    G = jumpForce;
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                playerModel.transform.rotation = Quaternion.Euler(playerModel.transform.rotation.x, 90 * Input.GetAxisRaw("Horizontal"), playerModel.transform.rotation.z);
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                playerModel.transform.rotation = Quaternion.Euler(playerModel.transform.rotation.x, 0, playerModel.transform.rotation.z);

            }

            if (Input.GetAxis("Vertical") < 0)
            {
                playerModel.transform.rotation = Quaternion.Euler(playerModel.transform.rotation.x, 180, playerModel.transform.rotation.z);

            }
        }
        
    }
}
