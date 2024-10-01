using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class LoaderScens : MonoBehaviour
{
    private bool _activeBonus;

    private void OnEnable()
    {
        EventSystem.StartTimeBonus += StartTime;
        EventSystem.EndTimeBonus += ReturnTime;
    }

    private void ReturnTime()
    {
        _activeBonus = false;
        Time.timeScale = 1;
    }

    private void StartTime()
    {
        _activeBonus = true;
        Time.timeScale = 0.5f;
    }

    private void OnDisable()
    {
        EventSystem.StartTimeBonus -= StartTime;
        EventSystem.EndTimeBonus -= ReturnTime;
    }

    public void LoadScene(int countScene)
    {
        KillTween();
        SceneManager.LoadScene(countScene);
    }

    public void FirstGame(int countScene)
    {
        if(Data.GetFirstGame())
        {
            LoadScene(countScene);
        }

        else
        {
            int traingScene = SceneManager.sceneCountInBuildSettings;
            Data.SaveFirstGame();
            LoadScene(traingScene -1);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        var NumberScene = SceneManager.GetActiveScene().buildIndex;
        KillTween();
        SceneManager.LoadScene(NumberScene);
    }

    public void NextScene()
    {
        var NumberScene = SceneManager.GetActiveScene().buildIndex;
        KillTween();
        SceneManager.LoadScene(NumberScene + 1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        KillTween();
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        if (_activeBonus)
            Time.timeScale = 0.5f;

        else
            Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void KillTween()
    {
        DOTween.Clear();
    }

}
