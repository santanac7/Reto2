using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    // Audio Source List
    [SerializeField] AudioSource _sound;
    [SerializeField] List<AudioClip> _soundsList = new List<AudioClip>();

    

    private void Awake() {
        if (AudioManager.instance == null) {
            AudioManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else{
            Destroy(gameObject);
        }        
    }   

    public void PlaySfx(int _sfx){
        AudioClip clip = _soundsList[_sfx];
        _sound.PlayOneShot(clip);
    }

    public void StopSfx(int _sfx)
    {
        AudioClip clip = _soundsList[_sfx];
        _sound.Stop();
    }
}