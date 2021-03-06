﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [Header("Change Level")]
    [SerializeField] private int currentLevel = 0;
    [SerializeField] private int nextLevel = 0;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private bool isMainMenu;

    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isInGame;
    private bool isInPauseMenu = false;

    [Header("Options Menu")]
    [SerializeField] private GameObject optionsMenu;

    [Header("Victory Screen")]
    [SerializeField] private GameObject victoryScreen;

    [Header("In Game UI")]
    [SerializeField] int score = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isMainMenu)
            BackToPreviousMenu();

        if (Input.GetKeyDown(KeyCode.Escape) && isInPauseMenu == false)
            Pause();

        if (Input.GetKeyDown(KeyCode.Escape) && isInGame && isInPauseMenu == true)
            Resume();
    }

    public void SetScore(int s) {

        score = s;

        GetComponentInChildren<Text>().text = score.ToString();

        Save.SaveData(score);
    }

    public void NextLevel() => SceneManager.LoadScene(nextLevel);


    public void CurrentLevel() => SceneManager.LoadScene(currentLevel);


    public void BackToMainMenu() => SceneManager.LoadScene(0);


    public void QuitGame() => Application.Quit();

    public void PlayGame() => NextLevel();

    public void Options()
    {
        if (isMainMenu)
            optionsMenu.SetActive(true);
        mainMenu.SetActive(false);

        if (isInGame)
            optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void BackToPreviousMenu()
    {

        if (isMainMenu)
            optionsMenu.SetActive(false);
        mainMenu.SetActive(true);

        if (isInGame)
            optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Victory() => victoryScreen.SetActive(true);

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isInPauseMenu = false;
    }

    public void Pause()
    {
        print(pauseMenu);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isInPauseMenu = true;
    }

}