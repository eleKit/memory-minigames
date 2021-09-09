using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicUtilitiesScript
{
    

    private AudioSource[] audio_sources;

    // true if using the game object name to start the music
    private bool useGONames = false;

    private Dictionary<string, AudioSource> music_list;

    private string current_music;

    public MusicUtilitiesScript( AudioSource[] m_audio_sources, bool m_useGONames)
    {
        audio_sources = m_audio_sources;
        useGONames = m_useGONames;

        music_list = new Dictionary<string, AudioSource>();

        for (int i = 0; i < audio_sources.Length; i++)
        {
            AudioSource s = audio_sources[i];
            //s.volume = 0f;
            if (useGONames)
                music_list[s.gameObject.name] = s;
            else
                music_list[s.clip.name] = s;
        }

    }

    

    public void Play(string name, bool loop = true, float pitchVariance = 0) //float volume = 0.15f,
    {
        if (music_list.ContainsKey(name))
        {
            if (pitchVariance != 0) music_list[name].pitch = 1 + Random.Range(-pitchVariance, pitchVariance);

            if (!music_list[name].isPlaying)
            {
                music_list[name].Play();
                music_list[name].loop = loop;
                //music_list[name].volume = volume;
                current_music = name;
            }


        }
        else Debug.LogWarning("No sound of name " + name + " exists");
    }

    public void Stop(string name)
    {
        if (music_list.ContainsKey(name))
        {
            if (music_list[name].isPlaying)
                music_list[name].Stop();
        }
        current_music = "";

    }

    public void Pause(string name)
    {
        if (music_list.ContainsKey(name))
        {
            if (music_list[name].isPlaying)
                music_list[name].Pause();
        }

    }

    public void UnPause(string name)
    {
        if (music_list.ContainsKey(name))
        {
            if (music_list[name].isPlaying)
                music_list[name].UnPause();
        }

    }

    public void MuteAll()
    {
        for (int i = 0; i < audio_sources.Length; i++)
            audio_sources[i].mute = true;
    }

    public void UnmuteAll()
    {
        for (int i = 0; i < audio_sources.Length; i++)
            audio_sources[i].mute = false;
    }

    public void StopAll()
    {
        for (int i = 0; i < audio_sources.Length; i++)
            audio_sources[i].Stop();
        current_music = "";
    }

    public void PauseAll()
    {
        for (int i = 0; i < audio_sources.Length; i++)
            audio_sources[i].Pause();
    }

    public void UnPauseAll()
    {
        for (int i = 0; i < audio_sources.Length; i++)
            audio_sources[i].UnPause();
    }

    public bool isPlaying(string name)
    {
        if (music_list.ContainsKey(name))
        {
            return music_list[name].isPlaying;
        }
        else
        {
            Debug.LogWarning("No sound of name " + name + " exists");
            return false;
        }
    }

    public string whatIsPlaying()
    {
        /*foreach (string key in music_list.Keys)
        {
            if (music_list[key].isPlaying)
                return key;
        }
        return "";*/
        return current_music;
    }

    /*public AudioSource PlayingSource()
    {
        return music_list[whatIsPlaying()];
    }*/

    public void ChangeVolume(float volume)
    {
        if (!current_music.Equals(""))
        {
            music_list[current_music].volume = volume;
        }

    }

    public float CurrentVolume()
    {
        if (!current_music.Equals(""))
        {
            return music_list[current_music].volume;
        }
        else
            return 0f;
    }

    public IEnumerator FadeNoChangeMusic(float final_volume, bool lower)
    {
        //StopAll();

        float current_volume = CurrentVolume();

        if (lower)
        {
            ChangeVolume(current_volume / 2); //0.2f
            yield return new WaitForSeconds(0.2f);
            ChangeVolume(current_volume / 3); //0.1f
            yield return new WaitForSeconds(0.2f);
            ChangeVolume(0.05f); // 0.05f
            yield return new WaitForSeconds(1f);

        }
        else
        {
            yield return new WaitForSeconds(1f);
            ChangeVolume(final_volume / 3); //0.1f
            yield return new WaitForSeconds(0.2f);
            ChangeVolume(final_volume / 2); // 0.2f
            yield return new WaitForSeconds(0.2f);
            ChangeVolume(final_volume);
        }
    }

    public IEnumerator Fade(string title_new_music) //, float final_volume)
    {
        StopAll();
        //float current_volume = CurrentVolume();
        //ChangeVolume(current_volume / 2); //0.2f
        //yield return new WaitForSeconds(0.2f);
        //ChangeVolume(current_volume / 3); //0.1f
        yield return new WaitForSeconds(1.5f);
        //ChangeVolume(0.05f); // 0.05f
        //yield return new WaitForSeconds(0.3f);

        //TODO check if lerp is useful here
        
        Play(title_new_music); //0.05f

        //yield return new WaitForSeconds(0.3f);
        //ChangeVolume(final_volume / 3); //0.1f
        //yield return new WaitForSeconds(0.2f);
        //ChangeVolume(final_volume / 2); // 0.2f
        //yield return new WaitForSeconds(0.2f);
        //ChangeVolume(final_volume ); // 0.3f
        //yield return new WaitForSeconds(0.2f);
        //ChangeVolume(0.5f);
    }



}
