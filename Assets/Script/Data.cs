using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Data 
{
    public static int GetHightScore(string level) => PlayerPrefs.GetInt(level);

    public static bool GetOpenLvl(string numberLevel) => PlayerPrefs.HasKey(numberLevel);

    public static bool GetFirstGame() => PlayerPrefs.HasKey("SaveFirstGame");

    public static int GetSelectBg() => PlayerPrefs.GetInt("OpenBg");


    public static void SaveScore(string level, int score)
    {
        float oldScore = 0;

        if (PlayerPrefs.HasKey(level))
        {
            oldScore = PlayerPrefs.GetInt(level);
        }

        if(score > oldScore)
        {
            PlayerPrefs.SetInt(level, score);
        }
    }

    public static void SaveLvl(string numberLvl)
    {
        if(PlayerPrefs.HasKey(numberLvl))
        {
            return;
        }

        else
        {
            PlayerPrefs.SetInt(numberLvl, 1);
        }
    }

    public static void SaveBackGr(int number)
    {
        PlayerPrefs.SetInt("OpenBg", number);
    }

    public static void SaveFirstGame()
    {
        PlayerPrefs.SetInt("SaveFirstGame", 1);
    }


    public static void GetLoad(List<GameObject> title, List<Text> score, List<Button> buttons)
    {
        if(!PlayerPrefs.HasKey("OpenBg"))
        {
            SaveBackGr(0);
        }

        var numberLvl = 1;

        if(!GetOpenLvl(numberLvl.ToString() + "Lvl"))
        {
            SaveLvl(numberLvl.ToString() + "Lvl");
        }

        for (int i =0; i < title.Count; i++)
        {
            if(GetOpenLvl(numberLvl.ToString() + "Lvl"))
            {
                title[i].SetActive(true);
                title[i].transform.parent.GetComponent<Button>().interactable = true;
                score[i].text = GetHightScore(numberLvl.ToString()).ToString();

                CheckOpenLvl(numberLvl, buttons);
            }

            else
            {
                title[i].SetActive(false);
                title[i].transform.parent.GetComponent<Button>().interactable = false;
                score[i].text = "0";
            }

            numberLvl++;
        }
    }

    private static void CheckOpenLvl(int numberLvl, List<Button> buttons)
    {
        switch (numberLvl)
        {
            case 4:
                buttons[1].interactable = true;
                break;

            case 7:
                buttons[2].interactable = true;
                break;

            case 10:
                buttons[3].interactable = true;
                break;

            case 13:
                buttons[4].interactable = true;
                break;
        }
    }

}
