using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AgentStepAudioPlayer : MonoBehaviour
{
    protected AudioSource audioSource;
    [SerializeField]
    protected float pitchRandomness = 0.05f;
    protected float basePitch;

    [SerializeField]
    protected AudioClip stepClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    private void Start()
    {
        basePitch = audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    private void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepClip);
    }
}
