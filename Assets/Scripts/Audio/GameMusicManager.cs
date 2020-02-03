using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioClip[] GameMusic;
    private float durationForSongs = 20f;
    private DoubleAudioSource doubleAudioSource;
    private int currentIdx=0;

    public float maxVol = 1;
    
    int RandomRangeExceptCurrent ()
    {
        int number = 0;
        do {
            number = Random.Range (0, GameMusic.Length);
        } while (number == currentIdx);
        return number;
    }
    
    IEnumerator PlayGameMusicLoop()
    {
        for (int i = 0; i < 100; i++)
        {
            PlaySound();
            yield return new  WaitForSeconds(durationForSongs);
        }
    }
    
    public void PlaySound()
    {
        currentIdx = RandomRangeExceptCurrent();
        doubleAudioSource.CrossFade(GameMusic[currentIdx], maxVol, 1, 0);

    }

    
    // Start is called before the first frame update
    void Start()
    {
        doubleAudioSource = GetComponent<DoubleAudioSource>();
        currentIdx = Random.Range(0, GameMusic.Length);
        StartCoroutine(PlayGameMusicLoop());
    }
    
}

