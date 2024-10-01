using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ClickBall : MonoBehaviour
{
    [SerializeField] private int _addScore = 5, _takeScore = 15;
    [SerializeField] private AudioSystem _audioSystem;

    private Sprite _currentBall;
    private Ray _ray;


    private void OnEnable() => EventSystem.CallChangeBallSprite += UpdateCurrentBall;

    private void OnDisable() => EventSystem.CallChangeBallSprite -= UpdateCurrentBall;

    private void UpdateCurrentBall(Sprite newBall)
    {
        _currentBall = newBall;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(_ray);

            if (hit2D)
            {
                var hitBall = hit2D.transform;
                var spriteHitBall = hitBall.gameObject.GetComponent<Image>().sprite;

                if (spriteHitBall == _currentBall)
                {
                    _audioSystem.SoundPlay(0);
                    
                    hitBall.DOKill();
                    hitBall.GetChild(0).gameObject.SetActive(true);
                    hitBall.GetComponent<Collider2D>().enabled = false;
                    Destroy(hitBall.gameObject, 2f);

                    EventSystem.RightHitBall?.Invoke(_addScore);

                    //hard code
                    if(SceneManager.GetActiveScene().buildIndex >= 10)
                    {
                        EventSystem.HideBall?.Invoke(hitBall.gameObject);
                    }
                }

                else
                {
                    _audioSystem.SoundPlay(1);

                    hitBall.DOShakeScale(1);
                    hitBall.GetComponent<Collider2D>().enabled = false;

                    EventSystem.PassBall?.Invoke(_takeScore);
                }
            }
        }
    }
}
