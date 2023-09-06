using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Species : MonoBehaviour
{
    private Color SpeciesColor { get; set; }
    private int EnergyToBeFed { get; set; }
    private float SpeciesSpeedMultiplier { get; set; } = 1;
    private float FoodDetectionRadius { get; set; } = 1;
    private string FoodType { get; set; } = "Gras";

    private float Movementspeed = 0.005f;
    private GameObject NearestFood;
    private bool FoodDetected = false;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = SpeciesColor;
    }

    private void Update()
    {
        Move();

        if (FoodDetected == false)
        {
            DetectFood();
        }
    }

    void Move()
    {
        CheckBoundry();
        if (FoodDetected == true)
        {
            Vector3 direction = NearestFood.transform.position - transform.position;

            var rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplier);

            if (NearestFood.transform.position == transform.position)
            {
                Eat();
            }
        }
        else
        {
            transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplier);
        }
    }

    void CheckBoundry()
    {
        if (transform.position.x < -4.8f || transform.position.x > 4.8f || transform.position.z < -4.8f || transform.position.z > 4.8f)
        {
            transform.Rotate(new Vector3(0, UnityEngine.Random.Range(110, 250), 0));
        }
    }

    void DetectFood()
    {
        if(FoodDetected == false)
        {
            GameObject[] FoodAvailabal = GameObject.FindGameObjectsWithTag(FoodType);

            for (int i = 0; i < FoodAvailabal.Length; i++)
            {
                float DistanceCheck = Vector3.Distance(transform.position, FoodAvailabal[i].transform.position);

                if (DistanceCheck < FoodDetectionRadius)
                {
                    NearestFood = FoodAvailabal[i];
                    FoodDetected = true;
                    break;
                }
            }
        }
    }

    void Eat()
    {

    }
}
