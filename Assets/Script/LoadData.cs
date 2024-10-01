using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField] private List<GameObject> _titleLevel;
    [SerializeField] private List<Text> _score;
    [SerializeField] private List<Button> _buttonBackGr;

    private void Start()
    {
        Data.GetLoad(_titleLevel, _score, _buttonBackGr);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        Data.GetLoad(_titleLevel, _score, _buttonBackGr);
    }

}
