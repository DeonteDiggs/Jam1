using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private static int artifactCount = 0;
    [SerializeField] private int maxArtifactCount = 0;
    MenuManager menuManager;


    private void Awake()
    {
        menuManager = new MenuManager();
    }


    public void TrackArtifactCount() {
        
        artifactCount++;

        if (artifactCount == maxArtifactCount)
            if (menuManager != null) 
                menuManager.Victory();    
    }

}
