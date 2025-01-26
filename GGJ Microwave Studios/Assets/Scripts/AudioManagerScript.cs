using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{

    [SerializeField] Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();
    public AudioMixer audioMixer;
    GameObject[] audioContainers = new GameObject[10];
    [SerializeField] bool FadeOutBool = false;
    [SerializeField] bool FadeInBool = false;
    private bool initialised = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        

    }
    
    void initialiseAudioMembers()
    {
        audioContainers = GameObject.FindGameObjectsWithTag("AudioObject");

        foreach (GameObject go in audioContainers)
        {
            audioSources.Add(go.name, go.GetComponent<AudioSource>());

        }
        initialised = true;

    }
    private void Update()
    {
        if (!initialised)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameScene"))
            {

                initialiseAudioMembers();
                PlaySound("BackgroundMusic");
                SetLoopingState("BackgroundMusic", true);

            }
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TestScene"))
            {

                initialiseAudioMembers();

            }

        }

        //TESTING
        if (FadeOutBool == true)
        {

            FadeOut("BossTheme");
            FadeOutBool = false;

        }
        if (FadeInBool == true)
        {

            FadeIn("BossTheme", 100.0f);
            FadeInBool = false;

        }
    }

   public float GetVolume(string name) { return audioSources[name].volume * 100.0f; }

   
    public void SetLoopingState(string name, bool looping)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].loop = looping;

        }

    }
  public void PlaySound(string name)
    {

        if (audioSources.ContainsKey(name))
        {
            audioSources[name].Play();
            if (name == "EnemyEncountered")
            {

                FadeIn("EnemyMusic", 75);

            }

        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }

    }

    public void PauseSound(string name)
    {

        if (audioSources.ContainsKey(name))
        {
            audioSources[name].Pause();
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }

    }
    public void UnPauseSound(string name)
    {

        if (audioSources.ContainsKey(name))
        {
            audioSources[name].UnPause();
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }

    }

    public void StopSound(string name)
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

    public void PitchUp(string name, float increase)
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
    public void PitchDown(string name, float decrease)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].pitch -= decrease;
        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }
    }

  public void SetVolume(string name, float volume)
    {
        volume /= 100.0f;
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].volume = volume;

        }
        else
        {
            Debug.Log("no AudioSource by name of " + name + " found");

        }
    }

    public void VolumeDown(string name)
    {
        if (audioSources.ContainsKey(name))
        {
            audioSources[name].volume -= 0.1f;

        }
        else
        {

            Debug.Log("no AudioSource by name of " + name + " found");
        }

    }

   public void FadeOut(string name)
    {

        StartCoroutine(FadeDown(name));
        StopSound(name);
    }

    public void FadeIn(string name, float vol)
    {
        vol /= 100.0f;
        PlaySound(name);
        StartCoroutine(FadeUp(name, vol));

    }
    IEnumerator FadeDown(string name)
    {
        float currentTime = 0.0f;
        float startVolume = audioSources[name].volume;
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            audioSources[name].volume = Mathf.Lerp(startVolume, 0.0f, currentTime / 5);
            yield return null;


        }
        yield break;
    }

    IEnumerator FadeUp(string name, float volume)
    {
        float currentTime = 0.0f;
        float startVolume = audioSources[name].volume;
        while (currentTime < 5)
        {
            currentTime += Time.deltaTime;
            audioSources[name].volume = Mathf.Lerp(startVolume, volume, currentTime / 5);
            yield return null;


        }
        yield break;
    }
}

