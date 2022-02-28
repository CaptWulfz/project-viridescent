using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudible
{
    public Sound[] Sounds { get; set; }
}

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip AudioClip;
}
