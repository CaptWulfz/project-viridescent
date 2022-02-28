using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GardenManager : Singleton<GardenManager>
{
    private const string GARDEN_MODELS_PATH = "AssetFiles/GardenModels";

    private GardenModels gardenModels;

    private List<Florae> activeFlorae;
    private List<PlantableSpot> plantableSpots;

    private bool isDone;
    public bool IsDone
    {
        get { return this.isDone; }
    }

    private void Start()
    {
        Initialize();  
    }

    #region Initialization
    private void Initialize()
    {
        this.gardenModels = Resources.Load<GardenModels>(GARDEN_MODELS_PATH);

        StartCoroutine(WaitForInitialization());
    }
    private IEnumerator WaitForInitialization()
    {
        yield return new WaitUntil(() => { return this.gardenModels != null; });

        this.gardenModels.FloraeReference.gameObject.SetActive(false);
        this.activeFlorae = new List<Florae>();
        this.plantableSpots = new List<PlantableSpot>();

        this.isDone = true;

        //SpawnFlorae(FloraeName.DAISY);
    }
    #endregion

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SpawnFlorae(FloraeName.EVERLASTING);
        }
    }

    private void SpawnFlorae(FloraeName floraeName)
    {
        GardenModels.FloraeModelEntry modelEntry= Array.Find<GardenModels.FloraeModelEntry>(this.gardenModels.FloraeModelEntries, (entry) => { return entry.Florae == floraeName; });
        if (modelEntry != null)
        {
            FloraeModel modelToLoad = modelEntry.FloraeModel;
            Florae florae = Florae.Instantiate<Florae>(this.gardenModels.FloraeReference, this.plantableSpots[0].transform);
            florae.transform.localPosition = Vector2.zero;
            florae.SetFloraeModel(modelToLoad);
            florae.Initialize();
            florae.gameObject.SetActive(true);

            this.activeFlorae.Add(florae);
        }
    }

    #region Injectors
    public void RegisterPlantableSpot(PlantableSpot spot)
    {
        this.plantableSpots.Add(spot);
    }
    #endregion
}
