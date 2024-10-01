using UnityEngine;

public class DontDestroyBackground : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}