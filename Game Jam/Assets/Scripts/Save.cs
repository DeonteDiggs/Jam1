using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Save : MonoBehaviour
{
    [SerializeField] GameObject Player;
    MenuManager menuManager;

    // Start is called before the first frame update
    void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            int xPos = PlayerPrefs.GetInt("Integer");

            Player.transform.position = new Vector3(xPos, Player.transform.position.y, Player.transform.position.z);

            float playerPositionX = PlayerPrefs.GetFloat("PlayerPositionX");
            float playerPositionY = PlayerPrefs.GetFloat("PlayerPositionY");
            float playerPositionZ = PlayerPrefs.GetFloat("PlayerPositionZ");
            Vector3 position = new Vector3(playerPositionX, playerPositionY, playerPositionZ);
            Player.transform.position = position;


            int score = PlayerPrefs.GetInt("Score");
            
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            CheckPoint(other.transform.position);    
    }

    void CheckPoint(Vector3 playerPosition)
    {
        PlayerPrefs.SetFloat("PlayerPositionX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPositionY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", playerPosition.z);
        PlayerPrefs.Save();
    }
    public static void SaveData(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

   
    
}
