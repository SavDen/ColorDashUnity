using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlBackground : MonoBehaviour
{
    //[Header("General Field")]


    [Header("Menu Field")]
    [SerializeField] private List<GameObject> _selectCircle;


    [Header("Game Field")]
    [SerializeField] private bool _inGame;
    [SerializeField] private List<Sprite> _backgrounds; //0-default 1-1 2-2 3-3 4-4
    [SerializeField] private Image _gameBackground;



    private void Start()
    {
        if(_inGame)
        _gameBackground.sprite = _backgrounds[Data.GetSelectBg()];

        ChangeSelectCircle();
    }

    public void ChangeBackGround(int number)
    {
        Data.SaveBackGr(number);
        ChangeSelectCircle();
    }

    private void ChangeSelectCircle()
    {
        for (int i = 0; i < _selectCircle.Count; i++)
        {
            if(i == Data.GetSelectBg())
            {
                _selectCircle[i].SetActive(true);
            }

            else
            {
                _selectCircle[i].SetActive(false);
            }
        }
    }
}
