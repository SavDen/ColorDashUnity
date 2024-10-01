using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{ 
    [SerializeField] private RectTransform _logo;
    [SerializeField] private float _duration, _delay;

    private void Start()
    {
       StartCoroutine(StartLoading());
    }

    private IEnumerator StartLoading()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(_logo.DOScale(0, 0));
        sequence.Append(_logo.DOScale(1, _duration));

        sequence.Play();

        yield return new WaitForSeconds(_delay);
        EnterGame();
    }

    private void EnterGame()
    {
        SceneManager.LoadScene(1);
    }
}
