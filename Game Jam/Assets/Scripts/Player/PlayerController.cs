using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Vector3 LastCheckpoint;
    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance.gameObject);
            Instance = this;
        } else
        {
            Instance = this;
        }
    }
    public enum PlayerType
    {
        Robot,
        Alien,
        Astronaut
    }

    public PlayerType playerType;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            InteractableObject IO = other.gameObject.GetComponent<InteractableObject>();
            if (IO.characterUse != this.playerType && !IO.anyCharacterCanUse)
            {
                Debug.Log("Access Denied");
                return;
            }

            Debug.Log("Access Granted");
            if (IO.type == InteractableObject.Type.Active)
            {
                KeyCode k = IO.keyCode;
                if (Input.GetKeyDown(k))
                {
                    IO.interact();
                }
            }

            if (IO.type == InteractableObject.Type.Passive)
            {
                IO.interact();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
