using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel, _bonusPanel;
    [SerializeField] private Text _actualScoreText, _needScoreText, _youScore;

    [SerializeField] private int _actualScore, _needScore;

    [SerializeField] private string _currentNumberLvl;

    [SerializeField] private float _bonusTime;

    [SerializeField] private bool _giftBackGround;
    [SerializeField] private GameObject _giftPanel;


    private void OnEnable()
    {
        EventSystem.PassBall += TakeScore;
        EventSystem.RightHitBall += AddScore;
    }

    private void OnDisable()
    {
        EventSystem.PassBall -= TakeScore;
        EventSystem.RightHitBall -= AddScore;
    }

    private void Awake()
    {
        UpdateUIScore();

        Data.SaveLvl(_currentNumberLvl + "Lvl");
        //print($"This Load saved {Data.GetOpenLvl(_currentNumberLvl)}");
    }

    private void AddScore(int addScore)
    {
        _actualScore += addScore;

        UpdateUIScore();

        if (_actualScore > Data.GetHightScore(_currentNumberLvl))
        {
            Data.SaveScore(_currentNumberLvl, _actualScore);
            //print($"Save Score, new Hight Score {Data.GetHightScore(_currentNumberLvl)}");
        }

        if (_actualScore%100 == 0)
            ActiveBonus();

        if (_actualScore == _needScore)
        {
            Win();
        }

    }

    private void TakeScore(int takeScore)
    {
        if (_actualScore - takeScore <= 0) _actualScore = 0;

        else _actualScore -= takeScore;

        UpdateUIScore();

    }

    private void UpdateUIScore()
    {
        _actualScoreText.text = _actualScore.ToString();
        _needScoreText.text = _needScore.ToString();
        _youScore.text = _needScore.ToString();
    }

    private void Win()
    {
        EventSystem.Win?.Invoke();

        _bonusPanel.SetActive(false);

        if(_giftBackGround)
        {
            _giftPanel.transform.DOScale(1, 1.5f).OnComplete(() =>
            {
                _giftPanel.transform.DOScale(0, 0.5f).OnComplete(() =>
                {
                    _winPanel.SetActive(true);
                    DOTween.KillAll();
                });
            });
        }

        else
        {
            _winPanel.SetActive(true);
            DOTween.KillAll();

        }
    }

    private void ActiveBonus()
    {
        _bonusPanel.transform.DOScale(1, 1.5f).OnComplete(() =>
        {
            _bonusPanel.transform.DOScale(0, 0.5f).OnComplete(() =>
        {
            StartCoroutine(BonusTime());
        });
        });
    }

    private IEnumerator BonusTime()
    {
        EventSystem.StartTimeBonus?.Invoke();

        print("StartBonus");
        yield return new WaitForSeconds(_bonusTime/2);
        print("EndBonus");
        EventSystem.EndTimeBonus?.Invoke();
    }


}
