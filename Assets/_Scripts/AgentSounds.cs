using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSounds : AudioPlayer
{
    [SerializeField]
    private AudioClip hitClip, deathClip, voiceLineClip;

    public void PlayHitSound()
    {
        PlayClipWithVariablePitch(hitClip);
    }

    public void PlayDeathSound()
    {
        PlayClipWithVariablePitch(deathClip);
    }

    public void PlayVoiceSound()
    {
        PlayClipWithVariablePitch(voiceLineClip);
    }
}
