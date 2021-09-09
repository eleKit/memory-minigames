using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{

    private AudioSource[] m_audio_sources;

    // true if using the game object name to start the music
    public bool m_useGONames = false;

    public MusicUtilitiesScript music_utilities_script;


    void Awake()
    {

        if (FindObjectsOfType(typeof(SFXManager)).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        m_audio_sources = gameObject.GetComponentsInChildren<AudioSource>();

        music_utilities_script = new MusicUtilitiesScript(m_audio_sources, m_useGONames);

    }
}
