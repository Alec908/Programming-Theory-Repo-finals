using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Species : MonoBehaviour
{

    protected float Movementspeed = 0.005f;

    protected int FoodEnergy { get; set; } // ENCAPSULATION

    protected virtual void Move(float SpeciesSpeedMultiplier)
    {
        CheckBoundry(); // ABSTRACTION
        transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplier);
    }

    protected virtual void MoveToFood(GameObject NearestFood, Vector3 position)
    {
        Vector3 direction = new Vector3(NearestFood.transform.position.x - transform.position.x, 0, NearestFood.transform.position.z - transform.position.z);

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

    protected virtual GameObject DetectFood(string FoodTag, float FoodDetectionRadius)
    {
        GameObject[] FoodAvailabal = GameObject.FindGameObjectsWithTag(FoodTag);

        for (int i = 0; i < FoodAvailabal.Length; i++)
        {
            float DistanceCheck = Vector3.Distance(transform.position, FoodAvailabal[i].transform.position);

            if (DistanceCheck < FoodDetectionRadius)
            {
                GameObject NearestFood = FoodAvailabal[i];
                return NearestFood;
            }
        }
        return null;
    }

    protected virtual int Eat(int CurrentEnergy, int EnergyToBeFed, int FoodEnergyValue, GameObject FoodObject)
    {
        Destroy(FoodObject);
        CurrentEnergy += FoodEnergyValue;
        return CurrentEnergy;
    }

    protected bool CheckIfHungry(int CurrentEnergy, int EnergyToBeFed)
    {
        if (CurrentEnergy >= EnergyToBeFed) 
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
