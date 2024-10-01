using System;
using UnityEngine;

public static class EventSystem
{
    public static Action<int> PassBall;
    public static Action<int> RightHitBall;

    public static Action<Sprite> CallChangeBallSprite;

    public static Action Win;

    public static Action StartTimeBonus;
    public static Action EndTimeBonus;

    public static Action<GameObject> HideBall;
}
