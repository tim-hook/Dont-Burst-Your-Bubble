using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerScript : MonoBehaviour
{

    [SerializeField] Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();
    GameObject[] audioContainers = new GameObject[1];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioContainers = GameObject.FindGameObjectsWithTag("AudioObject");

        foreach (GameObject go in audioContainers)
        {
            audioSources.Add(go.name, go.GetComponent<AudioSource>());

        }
         
        
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }

    void SetLoopingState(string name, bool looping)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].loop = looping;

        }

    }
    void PlaySound(string name)
    {

        if (audioSources.ContainsKey(name))
        {
            audioSources[name].Play();
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }

    }

    void StopSound (string name)
    {
        if (audioSources.ContainsKey(name))
        {

            audioSources[name].Stop();
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }
    }

    void PitchUp(string name, float increase)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].pitch += increase;
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }
    }
    void PitchDown(string name, float decrease) {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].pitch -= decrease;
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }
    }

    void SetVolume(string name, float volume)
    {
        if (audioSources.ContainsKey(name))
        {
        audioSources[name].volume = volume;

        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }
    }


}
