using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Orb : MonoBehaviour
{
    ParticleSystem particleSystem;
  
    SpriteRenderer sprite;

    MenuManager menuManager;

    int maxOrbCount = 0;
    static int counter = 0;

    private void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();

        maxOrbCount = FindObjectsOfType<Orb>().Length;

        particleSystem = GetComponent<ParticleSystem>();

        sprite = GetComponent<SpriteRenderer>();

        particleSystem.Stop();

    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
       {
            particleSystem.Play();

            sprite.enabled = false;

            Destroy(this, 1);

            counter++;
            
            menuManager.SetScore(counter);

            if (counter == maxOrbCount)
                GoalActivation();
       }
    }

    void GoalActivation()
    {
        print("Victory");
    }

}
