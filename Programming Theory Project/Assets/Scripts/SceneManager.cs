using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int SpeciesCount;
    public int GrasCount;

    private Vector3 SpawnPosition;
    private Quaternion SpawnRotation;

    public Species species;
    public GameObject Gras;

    void Start()
    {
        SpawnGras();
        SpawnSpecies();
    }

    void SpawnSpecies()
    {
        for (int i = 0; i < SpeciesCount; i++)
        {
            SpawnPosition = new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0.26f, UnityEngine.Random.Range(-4.5f, 4.5f));
            SpawnRotation.eulerAngles = new Vector3(0, UnityEngine.Random.Range(0, 359), 0);
            Instantiate(species, SpawnPosition, SpawnRotation);
        }
    }

    void SpawnGras()
    {
        for (int i = 0; i < GrasCount; i++)
        {
            SpawnPosition = new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), 0.15f, UnityEngine.Random.Range(-4.5f, 4.5f));
            SpawnRotation.eulerAngles = new Vector3(0, 0, 0);
            Instantiate(Gras, SpawnPosition, SpawnRotation);
        }
    }
}
