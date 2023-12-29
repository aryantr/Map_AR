using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlanet : MonoBehaviour
{
    public List<GameObject> planetPrefab;
    void Start()
    {
        GeneratePrefab();
    }

    void GeneratePrefab()
    {
        if(planetPrefab.Count > 0)
        {
            int randomIndex = Random.Range(0, planetPrefab.Count);
            Instantiate(planetPrefab[randomIndex], transform);
        }
    }
}
