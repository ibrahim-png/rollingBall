using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager:MonoBehaviour
{
    private static AudioSource _audioSource;

    public enum Sound
    {
        diamondCollect,
        pointBallCollect,
        jump,
        hitblock,
        gameOver

    }
    static soundManager(){
        if (_audioSource != null)
        {
            GameObject.Destroy(_audioSource);
        }
        else
        {
            GameObject gO = new GameObject("gO");
            _audioSource = gO.AddComponent<AudioSource>();
            DontDestroyOnLoad(_audioSource);
        }
    }

    public static void playSound(Sound sound)
    {
        //GameObject gO = new GameObject("gO");
        //gO.AddComponent<AudioSource>().PlayOneShot(getAudio(sound));
        _audioSource.PlayOneShot(getAudio(sound));
    }

    private static AudioClip getAudio(Sound sound)
    {
        foreach (var soundItem in soundAssets.instance.soundAudioClipArray)
        {
            if (soundItem.sound == sound)
            {
                return soundItem.audioClip;
            }
        }
        return null;
    }



  
}
