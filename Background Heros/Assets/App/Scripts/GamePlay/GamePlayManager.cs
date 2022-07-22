using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [Header("Parameters")]
    private GameState gameState;

    [Header("Links")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject DeadPanel;
    [SerializeField] private GameObject GamePlayPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private PlayerMovement player;

    private void IsDeadPlayer()
    {
        if(player.GetIsDead())
        {
            gameState = GameState.Dead;
        }
    }


    private void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.P) && gameState == GameState.GamePlay)
        {
            pausePanel.SetActive(true);
            DeadPanel.SetActive(false);
            GamePlayPanel.SetActive(false);
            gameState = GameState.Pause;
        }
        else if (Input.GetKeyDown(KeyCode.P) && gameState == GameState.Pause)
        {
            pausePanel.SetActive(false);
            DeadPanel.SetActive(false);
            GamePlayPanel.SetActive(true);
            gameState = GameState.GamePlay;
        }
    }

    private void Dead()
    {
        if(gameState == GameState.Dead)
        {
            Invoke("DeadPanelSetActive", 1.5f);
        }
    }

    private void DeadPanelSetActive()
    {
        pausePanel.SetActive(false);
        DeadPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        DeadPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
        gameState = GameState.GamePlay;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        pausePanel.SetActive(false);
        DeadPanel.SetActive(false);
        GamePlayPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        PauseMenu();
    }

    private void FixedUpdate()
    {
        IsDeadPlayer();
        Dead();
    }

}

public enum GameState {GamePlay, Dead, Pause}; 
