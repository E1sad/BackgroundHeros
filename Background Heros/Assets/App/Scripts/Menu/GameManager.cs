using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject aboutCanvas, settingsCanvas;

    private void FirstStart()
    {
        aboutCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }

    public void BackSettings()
    {
        settingsCanvas.SetActive(false);
    }
    public void BackAbout()
    {
        aboutCanvas.SetActive(false);
    }
    public void Settings()
    {
        aboutCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    public void About()
    {
        settingsCanvas.SetActive(false);
        aboutCanvas.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        FirstStart();
    }
}
