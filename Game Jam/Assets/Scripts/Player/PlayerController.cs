using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
