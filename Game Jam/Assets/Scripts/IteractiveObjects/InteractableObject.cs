using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    public UnityEvent OnUse;
    public KeyCode keyCode;
    public int numberOfUses;
    public int allowedUses;
    public bool UnlimitedUse;
    public enum Type
    {
        Active,
        Passive
    }

    public PlayerController.PlayerType characterUse;

    public Type type;
    public void interact()
    {
        if (numberOfUses >= allowedUses && !UnlimitedUse)
        {
            if (type == Type.Passive)
            {
                return;
            }
            cantUse();
            return;
        }
        OnUse.Invoke();
        numberOfUses++;
    }

    void cantUse()
    {
       
        AudioManager.Instance.PlayClip("CantUse");
    }
}
