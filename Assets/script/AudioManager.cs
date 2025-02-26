using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   public AudioClip[] playlist;

    public AudioSource audioSource;
    private int musicIndex=0;

    public AudioMixerGroup soundEffectmixer;

    public static AudioManager instance;

   

    private void Awake(){

        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }
        instance = this;
    }


    void Start()
    {
        PlayRandom();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandom();
        }
    }

    void PlayRandom()
    {
        musicIndex = Random.Range(0, playlist.Length);
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource CreateAudioSource(AudioClip clip, Vector3 pos)
    {
        GameObject tempGo = new GameObject("TempAudio");
        tempGo.transform.position = pos;
        AudioSource aSource = tempGo.AddComponent<AudioSource>();
        aSource.clip = clip;
        aSource.outputAudioMixerGroup = soundEffectmixer;
        aSource.Play();
        Destroy(tempGo, clip.length);
        return aSource;
    }
}
