using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundManager : MonoBehaviour
{

    private bool notesClimbingUp;
    private int noteIdx;
    public AudioClip[] notes;
    public AudioClip[] chords;
    private AudioSource source;
    void Awake ()
    {
        notesClimbingUp=(Random.value > 0.5f);
        noteIdx = Random.Range(0, notes.Length);
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Goes up the notes, then goes down the notes
    /// </summary>
    /// <returns></returns>
    int GetNextNoteIdx()
    {
        if (notesClimbingUp)
        {
            if (noteIdx != notes.Length - 1)
            {
                noteIdx++;
            }
            else
            {
                notesClimbingUp = false;
                noteIdx--;
            }
        }
        else
        {
            if (noteIdx != 0)
            {
                noteIdx--;
            }
            else
            {
                notesClimbingUp = true;
                noteIdx++;
            }
        }

        return noteIdx;
    }


    public void PlayNote()
    {
        source.PlayOneShot(notes[GetNextNoteIdx()]);
    }

    public void PlayChord()
    {
        source.PlayOneShot(chords[Random.Range(0, chords.Length)]);
    }

}
