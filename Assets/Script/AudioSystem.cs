using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips; //0-Right, 1-Pass

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SoundPlay(int sound)
    {
        _audioSource.clip = _audioClips[sound];
        _audioSource.Play();
    }
}
