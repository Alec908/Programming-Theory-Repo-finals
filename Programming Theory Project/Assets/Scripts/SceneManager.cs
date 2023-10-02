using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int SpeciesCount;
    [Range (0 , 1)]
    public float PredatorPercentage;
    public int GrassCount;

    public GameObject Prey;
    public GameObject Predator;
    public GameObject Gras;


    void Start()
    {
        for(int i = 0; i < GrassCount; i++)
        {
            Vector3 Spawnpoint = new Vector3(Random.Range(-4.5f, 4.5f), 0.045f, Random.Range(-4.5f, 4.5f));
            Instantiate(Gras, Spawnpoint, Quaternion.Euler(0, 0, 0));
        }

        for (int i = 0; i < SpeciesCount; i++)
        {
            Vector3 Spawnpoint = new Vector3 (Random.Range(-4.5f , 4.5f), 0.3f, Random.Range(-4.5f , 4.5f));
            Quaternion SpawnRotation = Quaternion.Euler(0, Random.Range(0, 359), 0);
            Instantiate(Prey, Spawnpoint, SpawnRotation);
        }
        for (int i = 0; i < (SpeciesCount * PredatorPercentage); i++)
        {
            Vector3 Spawnpoint = new Vector3(Random.Range(-4.5f, 4.5f), 0.3f, Random.Range(-4.5f, 4.5f));
            Quaternion SpawnRotation = Quaternion.Euler(0, Random.Range(0, 359), 0);
            Instantiate(Predator, Spawnpoint, SpawnRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
