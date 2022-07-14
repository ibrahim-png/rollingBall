using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundAssets : MonoBehaviour
{
    private static soundAssets _instance;

    public static soundAssets instance
    {
        get{
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<soundAssets>("soundAssets"));
            }
            DontDestroyOnLoad(_instance);
            return _instance;
        }
    }

    public soundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class soundAudioClip{
        public soundManager.Sound sound;
        public AudioClip audioClip;
    }
}
