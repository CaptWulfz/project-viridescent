using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GardenModels", menuName = "Database/Garden Models")]
public class GardenModels : ScriptableObject
{
    [System.Serializable]
    public class FloraeModelEntry
    {
        public FloraeName Florae;
        public FloraeModel FloraeModel;
    }

    [field: SerializeField]
    public Florae FloraeReference { get; set; }

    public FloraeModelEntry[] FloraeModelEntries;
}

public enum FloraeName
{
    DAISY,
    EVERLASTING,
    LAVENDER,
    PHALAENOPSIS,
    ROSE,
    SAKURA,
    SUNFLOWER,
    VIOLETS
}
