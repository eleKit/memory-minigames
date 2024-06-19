using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : Singleton<MusicManager>
{

    private AudioSource[] m_audio_sources;

    // true if using the game object name to start the music
    public bool m_useGONames = false;

    public MusicUtilitiesScript music_utilities_script;


    void Awake()
    {

        if (FindObjectsOfType(typeof(MusicManager)).Length > 1)
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


    private void Update()
    {
        
    }






}
