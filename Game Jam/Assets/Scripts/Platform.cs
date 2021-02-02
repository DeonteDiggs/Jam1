using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool frontviewPlatform;
    public BoxCollider extendedCol_1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is on the same side of the map as this platform
        if (frontviewPlatform == LevelMovement.Instance.frontView)
        {
            extendedCol_1.enabled = false;
        } else
        {
            extendedCol_1.enabled = true;
        }

        //if true disable second collier

        //if false enable second collider
    }
}
