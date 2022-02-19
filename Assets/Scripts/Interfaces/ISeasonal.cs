using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeasonType
{
    SPRING,
    SUMMER,
    FALL,
    WINTER
}

public interface ISeasonal
{
    public SeasonType SeasonType { get; set; }
}
