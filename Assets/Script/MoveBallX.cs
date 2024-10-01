using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class MoveBallX
{
    public void Move(RectTransform transform, RectTransform target, float speed)
    {
        var direction = new Vector3(target.position.x, 0f, 0f);
        transform.DOMoveX(direction.x, speed).SetEase(Ease.Linear).OnComplete(() =>
        { transform.transform.gameObject.SetActive(false); }).OnComplete(() =>
        { EventSystem.HideBall?.Invoke(transform.gameObject); });
    }
}
