using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class MoveBallY 
{
    public void Move(RectTransform transform, RectTransform target, float speed)
    {
        var direction = new Vector3(0, target.position.y, 0f);
        transform.DOMoveY(direction.y, speed).SetEase(Ease.Linear).OnComplete(() =>
        { transform.gameObject.SetActive(false); }).OnComplete(() =>
        { EventSystem.HideBall?.Invoke(transform.gameObject); });
    }
}
