using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutUp : MonoBehaviour {

    private AudioSource[] allAudioSources;
    public int decider = 1;

	public void DecideAllAudio(int decider)
    {

        if (decider == 0)
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.Pause();
            }
        }

        else if (decider == 1)
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.UnPause();
            }
        }
    }

    private void Update()
    {
        DecideAllAudio(decider);
    }
}
