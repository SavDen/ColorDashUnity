using UnityEngine;
using DG.Tweening;


public class BetweenScreen : MonoBehaviour
{
    [SerializeField] private RectTransform _detweenScreen;
    [SerializeField] private bool _unScale;
    [SerializeField] private float _duration;

    private void Awake()
    {
        _detweenScreen.transform.localScale = Vector3.zero;
    }

    private void Start()
    {
        if (!_unScale)
            BetweenScrenPlay();
    }

    public void BetweenScrenPlay()
    {
        _detweenScreen.DOScale(1, _duration).OnComplete(() =>
        {
            if(_unScale)
            _detweenScreen.DOScale(0, 0);
        });
    }

}
