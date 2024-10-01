using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    [SerializeField] private MoveBallY _moveBallY;

    [Header("SpawnObject")]
    [SerializeField] protected List<GameObject> _prefabs;
    [SerializeField] protected List<RectTransform> _pointSpawn;

    [Header("TargetBall")]
    [SerializeField] protected List<Sprite> _variantBall;
    [SerializeField] protected Image _currentTargetBall;
    [SerializeField, Min(1)] protected float _timeChange;

    [Header("SpawnSetting")]
    [SerializeField] protected float _durationSpawn;
    [SerializeField] protected List<float> _speed; //0 - min, 1 - max
    [SerializeField] protected RectTransform _targetToMove;


    public Sprite GetSprite => _currentTargetBall.sprite;

    public virtual void OnEnable()
    {
        EventSystem.Win += StopSpawn;
    }

    public virtual void OnDisable()
    {
        EventSystem.Win -= StopSpawn;
    }


    public virtual void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(ChangeTargetBall());
    }

    private void StopSpawn()
    {
        StopAllCoroutines();

        foreach(var point in _pointSpawn)
        {
            point.gameObject.SetActive(false);
        }
    }

    public virtual IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(_durationSpawn);

            RectTransform newBall = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)],
                _pointSpawn[Random.Range(0, _pointSpawn.Count)]).GetComponent<RectTransform>();

            newBall.anchoredPosition = Vector2.zero;

            _moveBallY.Move(newBall, _targetToMove, Random.Range(_speed[0], _speed[1]));
        }
    }

    private IEnumerator ChangeTargetBall()
    {
        while(true)
        {
            _currentTargetBall.sprite = ChangeBall();

            _currentTargetBall.transform.DOShakeScale(1);

            EventSystem.CallChangeBallSprite?.Invoke(GetSprite);

            yield return new WaitForSeconds(_timeChange);
        }

    }

    public virtual Sprite ChangeBall()
    {
        return _variantBall[Random.Range(0, _variantBall.Count -1)];
    }


    
}
