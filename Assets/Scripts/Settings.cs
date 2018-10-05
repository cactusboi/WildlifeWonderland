using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour {

    public AudioMixer Audio;

    public void SetVolume(float Volume)
    {
        //Debug.Log(Volume);
        Audio.SetFloat("Volume", Volume);
    }
}
