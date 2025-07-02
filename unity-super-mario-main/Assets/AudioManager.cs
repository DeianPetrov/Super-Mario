using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AudioManager : MonoBehaviour
{

    AudioManager audioManager;
    private PlayerSpriteRenderer psr;
    [Header("Audio Source")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource SFX;
    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip jump;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        audioSource.clip = background;
        audioSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        
        SFX.PlayOneShot(clip);
    }
   


}
