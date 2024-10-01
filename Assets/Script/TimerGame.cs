using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private Text _yourTime;

    private float _startTime;
    private float _endTime;

    private void OnEnable() => EventSystem.Win += EndGame;


    private void OnDisable() => EventSystem.Win -= EndGame;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void EndGame()
    {
        _endTime = Time.time - _startTime;
        _yourTime.text = SecondsToMinut(_endTime).ToString();
    }

    private string SecondsToMinut(double time)
    {
        if (time < 60)
            return TimeSpan.FromSeconds(time).ToString(@"ss");
        else if (time > 60 && time < 3600)
            return TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        else
            return TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");

    }
}
