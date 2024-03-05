using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    AudioSource audio;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable IDE0052 // Remove unread private members
    private bool didPlay;
#pragma warning restore IDE0052 // Remove unread private members


    private void Awake()
    {
        audio = GetComponent<AudioSource>();    
    }

    //manages play/stop/etc.
    public void Init(AudioClip clip) { //shorthand for initialize, could be set 
        audio.clip = clip;

    }

    public void Play() { 
        audio.Play();
        didPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
#pragma warning disable CS0665 // Assignment in conditional expression is always constant
        if (didPlay = false) return;
#pragma warning restore CS0665 // Assignment in conditional expression is always constant
        if (audio.isPlaying == false) Destroy(gameObject);
        // or if did play {if isplaying}
    }
}
