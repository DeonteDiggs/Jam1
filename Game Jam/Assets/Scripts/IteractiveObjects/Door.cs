using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider barrierCollider;
    public Material transparent;
    public void Use()
    {
        barrierCollider.gameObject.GetComponent<MeshRenderer>().material = transparent;
        barrierCollider.enabled = false;
    }
}
