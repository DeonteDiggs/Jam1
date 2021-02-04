using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public static LevelMovement Instance;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            GameObject.Destroy(this);
        }
    }
    #endregion

    public bool rotating;
    float dir;
    float tracker;
    public float rotationSpeed;
    public bool frontView = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !rotating)
        {
            dir = 90;
            rotating = true;
            frontView = !frontView;
        }

        if (Input.GetKeyDown(KeyCode.E) && !rotating)
        {
            dir = -90;
            
            rotating = true;
            frontView = !frontView;

        }

        if (rotating)
        {
            RotateMap(dir, rotationSpeed);
        }

    }

    void RotateMap(float rotAmount, float rotSpeed)
    {
        float speed = rotAmount * Time.deltaTime * rotSpeed;
        tracker += Mathf.Abs(speed);
        transform.eulerAngles += new Vector3(0, speed, 0);

        if (tracker >= Mathf.Abs(rotAmount))
        {
            rotating = false;
            tracker = 0;
            float f = Mathf.Round((transform.eulerAngles.y)/ Mathf.Abs(rotAmount));
            transform.eulerAngles = new Vector3(0, f * Mathf.Abs(rotAmount), 0);
        }

    }
}
