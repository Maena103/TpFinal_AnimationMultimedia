using UnityEngine;
using UnityEngine.Audio;

public class GestionAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;


    public void ChangeVolumeMusique(float value)
    {
        _audioMixer.SetFloat("volumeMusique", value);
    }

    public void ChangeVolumeEffets(float value)
    {
        _audioMixer.SetFloat("volumeEffets", value);
    }
}
