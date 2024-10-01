using UnityEngine;
using DG.Tweening;

public class TriggerPassBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.DOKill();
        other.gameObject.SetActive(false);
    }
}
