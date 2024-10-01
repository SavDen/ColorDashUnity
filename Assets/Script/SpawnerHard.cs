
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnerHard : Spawner
{
    [SerializeField] private MoveBallX _moveBallX;

    [SerializeField] private float _timeChangeAllBall;

    [SerializeField] private List<Sprite> _circleBall;

    private List<GameObject> _ballsCollection = new();

    public override void OnEnable()
    {
        base.OnEnable();
        EventSystem.HideBall += RemoveCollectionBall;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EventSystem.HideBall -= RemoveCollectionBall;
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(ChangeBalls());
    }

    public override IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_durationSpawn);

            RectTransform newBall = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)],
                _pointSpawn[Random.Range(0, _pointSpawn.Count)]).GetComponent<RectTransform>();

            newBall.anchoredPosition = Vector2.zero;

            _moveBallX.Move(newBall, _targetToMove, Random.Range(_speed[0], _speed[1]));
            AddCollectionBall(newBall.gameObject);
        }
    }

    private void AddCollectionBall(GameObject newBall)
    {
        _ballsCollection.Add(newBall);
    }

    private void RemoveCollectionBall(GameObject ball)
    {
        _ballsCollection.RemoveAt(_ballsCollection.IndexOf(ball));
    }

    private IEnumerator ChangeBalls()
    {
        while (true)
        {
            ChangeAllBall();

            yield return new WaitForSeconds(_timeChangeAllBall);
        }
    }

    private void ChangeAllBall()
    {
        if (_ballsCollection.Count == 0) return;

        foreach(var ball in _ballsCollection)
        {
            if(ball)
            {
                ball.GetComponent<Image>().sprite = ChangeBall();

                var idBall = int.Parse(ball.GetComponent<Image>().sprite.name) - 10;
                ball.transform.GetChild(0).GetComponent<Image>().sprite = _circleBall[idBall];
            }
        }
    }


}
