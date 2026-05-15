using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    public string soundName;
    public int id;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(0.1f, 3f)]
    public float pitch = 1f;

    public bool loop;
    [HideInInspector] public AudioSource source;
}

public class AudioManage : MonoBehaviour
{
    [SerializeField] private List<SoundData> sounds = new List<SoundData>();

    private void Start()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            sounds[i].id = i;

            sounds[i].source = gameObject.AddComponent<AudioSource>();
            sounds[i].source.clip = sounds[i].clip;
            sounds[i].source.volume = sounds[i].volume;
            sounds[i].source.pitch = sounds[i].pitch;
            sounds[i].source.loop = sounds[i].loop;
            sounds[i].source.playOnAwake = false;
        }
        PlayLoop("theme");
    }

    public void PlaySound(string soundName)
    {
        SoundData s = sounds.Find(x => x.soundName == soundName);
        if (s == null)
        {
            Debug.LogWarning($"Sound not found: {soundName}");
            return;
        }

        s.source.loop = false;
        s.source.Play();
    }

    public void PlaySound(int id)
    {
        SoundData s = sounds.Find(x => x.id == id);
        if (s == null)
        {
            Debug.LogWarning($"Sound id not found: {id}");
            return;
        }

        s.source.loop = false;
        s.source.Play();
    }

    public void PlayLoop(string soundName)
    {
        SoundData s = sounds.Find(x => x.soundName == soundName);
        if (s == null)
        {
            Debug.LogWarning($"Sound not found: {soundName}");
            return;
        }

        s.source.loop = true;
        if (!s.source.isPlaying)
            s.source.Play();
    }

    public void PlayLoop(int id)
    {
        SoundData s = sounds.Find(x => x.id == id);
        if (s == null)
        {
            Debug.LogWarning($"Sound id not found: {id}");
            return;
        }

        s.source.loop = true;
        if (!s.source.isPlaying)
            s.source.Play();
    }

    public void StopSound(string soundName)
    {
        SoundData s = sounds.Find(x => x.soundName == soundName);
        if (s == null)
        {
            Debug.LogWarning($"Sound not found: {soundName}");
            return;
        }

        s.source.Stop();
    }

    public void StopSound(int id)
    {
        SoundData s = sounds.Find(x => x.id == id);
        if (s == null)
        {
            Debug.LogWarning($"Sound id not found: {id}");
            return;
        }

        s.source.Stop();
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (sounds[i].source != null)
                sounds[i].source.Stop();
        }
    }
}