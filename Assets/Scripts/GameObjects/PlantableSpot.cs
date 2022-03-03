using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableSpot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(WaitForGardenManagerInitialization());
    }

    private IEnumerator WaitForGardenManagerInitialization()
    {
        yield return new WaitUntil(() => { return GardenManager.Instance.IsDone; });

        GardenManager.Instance.RegisterPlantableSpot(this);
    }

    public void OnPlantableSpotSelected()
    {

    }
}
