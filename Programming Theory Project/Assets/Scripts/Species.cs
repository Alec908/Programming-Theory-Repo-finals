using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Species : MonoBehaviour
{
    private float SpeciesSpeedMultiplier;
    private float FoodDetectionRadius;

    protected float Movementspeed = 0.005f;
    protected GameObject NearestFood;
    private bool FoodDetected = false;


    protected virtual void Move()
    {
        CheckBoundry();
        transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplier);
    }

    protected void MoveToFood()
    {
        Vector3 direction = NearestFood.transform.position - transform.position;

        var rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        transform.Translate(Vector3.forward * Movementspeed);
    }

    protected void CheckBoundry()
    {
        if (transform.position.x < -4.8f || transform.position.x > 4.8f || transform.position.z < -4.8f || transform.position.z > 4.8f)
        {
            transform.Rotate(new Vector3(0, UnityEngine.Random.Range(110, 250), 0));
        }
    }

    protected void SetColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    protected GameObject DetectFood(string FoodTag)
    {
        GameObject[] FoodAvailabal = GameObject.FindGameObjectsWithTag(FoodTag);

        for (int i = 0; i < FoodAvailabal.Length; i++)
        {
            float DistanceCheck = Vector3.Distance(transform.position, FoodAvailabal[i].transform.position);

            if (DistanceCheck < FoodDetectionRadius)
            {
                NearestFood = FoodAvailabal[i];
                break;
            }
        }
        return NearestFood;
    }

    void Eat(int EnergyToBeFed, int FoodEnergyValue)
    {
        Destroy(NearestFood);
        EnergyToBeFed += FoodEnergyValue;
    }

    protected bool CheckIfHungry(int CurrentEnergy, int EnergyToBeFed)
    {
        if (CurrentEnergy > EnergyToBeFed) 
        { 
            return false;
        }
        return true;
    }
}
