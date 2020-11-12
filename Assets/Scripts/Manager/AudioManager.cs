using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager {

    private static AudioManager instance;
    public static AudioManager Instance()
    {
        if (instance == null)
            instance = new AudioManager();
        return instance;
    }
    private AudioManager() { }

    public void AudioPlay(AudioSource _audio)
    {
        if(!_audio.isPlaying)
            _audio.Play();
    }

    public void AudioPause(AudioSource _audio)
    {
        if (_audio.isPlaying)
            _audio.Pause();
    }

    public void AudioUnPause(AudioSource _audio)
    {
        _audio.UnPause();
    }

    public void AudioStop(AudioSource _audio)
    {
        _audio.Stop();
    }
}
