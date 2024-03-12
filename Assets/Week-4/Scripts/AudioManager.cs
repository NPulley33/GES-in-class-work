using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance; //single instance that the entire application can use

    [SerializeField]
    [Tooltip("You should specify the sound effect prefab")]
    GameObject SoundEffectPrefab;

    [Header("Audio Clips")]
    [SerializeField] AudioClip attack;
    [SerializeField] AudioClip damage;
    [SerializeField] AudioClip music;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private AudioSource audio;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public enum SoundType { 
        //NONE = -1
        ATTACK = 0, //don't have to specify the numbers, but you should
        DAMAGE = 1,
        MUSIC = 3
    }

    private void Awake()
    {
        //when going between levels, this object will not be destroyed
        //step in process of making it global
        DontDestroyOnLoad(this);
        instance = this;
    }

    public static void PlaySound(SoundType s) {
        //if instance is null make a new instance
        instance.privPlaySound(s);  
    }
    private void privPlaySound(SoundType s) {
        /*switch (s) { 
            case SoundType.ATTACK: audio.PlayOneShot(attack); break;
            case SoundType.DAMAGE: audio.PlayOneShot(damage); break;
            case SoundType.MUSIC: audio.PlayOneShot(music); break;
        }   */

        AudioClip clip = null;

        switch (s) { 
            case SoundType.ATTACK: clip = attack; break;
            case SoundType.DAMAGE: clip = damage; break;
            case SoundType.MUSIC: clip = music; break;
        }

        GameObject soundEffectObject = Instantiate(SoundEffectPrefab);
        SoundEffect soundEffect = soundEffectObject.AddComponent<SoundEffect>();
        soundEffect.Init(clip);
        soundEffect.Play();

    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A)) privPlaySound(SoundType.MUSIC); 
    }

}
