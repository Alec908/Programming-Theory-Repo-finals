using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Species : MonoBehaviour
{
    private float SpeciesSpeedMultiplier;

    protected float Movementspeed = 0.005f;
    protected GameObject NearestFood;

    protected int FoodEnergyGras = 10;
    protected int FoodEnergyFlesh = 50;

    protected virtual void Move()
    {
        CheckBoundry();
        transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplier);
    }

    protected virtual void MoveToFood()
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

    protected virtual void DetectFood(string FoodTag, float FoodDetectionRadius)
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
    }

    protected int Eat(int CurrentEnergy, int EnergyToBeFed, int FoodEnergyValue, GameObject FoodObject)
    {
        Destroy(FoodObject);
        CurrentEnergy += FoodEnergyValue;
        return CurrentEnergy;
    }

    protected bool CheckIfHungry(int CurrentEnergy, int EnergyToBeFed)
    {
        if (CurrentEnergy > EnergyToBeFed) 
        { 
            return false;
        }
        return true;
    }

    protected int Hunger(int CurrentEnergyLevel)
    {
        if (Time.deltaTime >= 5 && CurrentEnergyLevel >= 0)
        {
            CurrentEnergyLevel -= 5;
        }
        return CurrentEnergyLevel;
    }
}
