using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource PublicAudioSource;
    [SerializeField] AudioSource BackGroundAudio;
    public void SetBGMusic(AudioClip BGAudioClip)
    {
        BackGroundAudio.clip = BGAudioClip;
        BackGroundAudio.Play();
    }
    public void PlayBackGroundMusic()
    {
        BackGroundAudio.Play();
    }
    public void StopBackGroundMusic()
    {
        BackGroundAudio.Stop();
    }
    public void PlaySound(AudioClip clip)
    {
        PublicAudioSource.PlayOneShot(clip);
    }
}
