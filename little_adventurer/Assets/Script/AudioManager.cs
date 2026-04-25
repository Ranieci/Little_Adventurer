using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip swordSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayMusic();
    }
    
    public void PlayMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySwordSound()
    {
        sfxSource.PlayOneShot(swordSound);
    }

    public void PlayWinSound()
    {
        sfxSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        sfxSource.PlayOneShot(loseSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
