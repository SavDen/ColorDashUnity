using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Share : MonoBehaviour
{
    public void ShareClick()
    {
        new NativeShare().SetText("ColorDash Frenzy")
            .SetUrl("https://apps.apple.com/app/colordash-frenzy/id6711351353")
            .SetCallback((result, shareTarget) =>
            Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
        .Share();
    }
}
