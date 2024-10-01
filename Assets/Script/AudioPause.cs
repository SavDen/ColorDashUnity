using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

[Serializable]
public class AudioPause: MonoBehaviour
{
    [SerializeField] private Image[] _image; //0-mus, 1-sound
    [SerializeField] private Sprite[] _sprite; //0-1(on/off) mus, 2-3(on/off) sound
    [SerializeField] private AudioMixer _mixer;


    private static bool _musOn = true;
    private static bool _soundOn = true;

    private void Start()
    {
        StartSprite();
    }

    public void MusisButton ()
    {
        if(_musOn)
        {
            _image[0].sprite = _sprite[1];
            _mixer.SetFloat("Music", -80f);
            _musOn = false;
        }

        else
        {
            _image[0].sprite = _sprite[0];
            _mixer.SetFloat("Music", 0f);
            _musOn = true;
        }
    }

    public void SoundButton()
    {
        if (_soundOn)
        {
            _image[1].sprite = _sprite[3];
            _mixer.SetFloat("Sound", -80f);
            _soundOn = false;
        }

        else
        {
            _image[1].sprite = _sprite[2];
            _mixer.SetFloat("Sound", 0f);
            _soundOn = true;
        }
    }

    private void StartSprite()
    {
        MusSprite();
        SoundSprite();
    }

    private void MusSprite()
    {
        if (_musOn)
        {
            _image[0].sprite = _sprite[0];
        }

        else
        {
            _image[0].sprite = _sprite[1];
        }
    }

    private void SoundSprite()
    {
        if (_soundOn)
        {
            _image[1].sprite = _sprite[2];
        }

        else
        {
            _image[1].sprite = _sprite[3];
        }
    }
}
