using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Prey : Species
{
    //Species characteristics

    private Color Color = Color.blue;
    private string FoodType = "Gras";
    private GameObject MyFood;
    private int EnergyToBeFed = 100;
    private float SpeciesSpeedMultiplicator = 1.0f;
    private float FoodDetectionRadius = 1.0f;

    //Status
    private bool Hungry  = true;
    private bool FoodDetected = false;
    private int CurrentEnergyLevel = 0;
    private float DistanceCheck = Mathf.Infinity;
    


    private void Start()
    {
        base.SetColor(Color);
    }

    private void Update()
    {
        Hungry = base.CheckIfHungry(CurrentEnergyLevel, EnergyToBeFed);
        if (Hungry == true && MyFood != null)
        {
            MoveToFood();
        }
        else
        {
            Move();
            DetectFood(FoodType,FoodDetectionRadius);
        }
        CurrentEnergyLevel = base.Hunger(CurrentEnergyLevel);
        Debug.Log($"Energy: {CurrentEnergyLevel}, Food:{MyFood}");
    }

    protected override void Move()
    {
        base.CheckBoundry();
        transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplicator);
    }

    protected override void MoveToFood()
    {
        if (DistanceCheck < 1)
        {
            CurrentEnergyLevel = base.Eat(CurrentEnergyLevel, EnergyToBeFed, FoodEnergyGras, MyFood);
        }
    }

    protected override void DetectFood(string FoodTag, float FoodDetectionRadius)
    {
        GameObject[] FoodAvailabal = GameObject.FindGameObjectsWithTag(FoodTag);

        for (int i = 0; i < FoodAvailabal.Length; i++)
        {
            DistanceCheck = Vector3.Distance(transform.position, FoodAvailabal[i].transform.position);

            if (DistanceCheck < FoodDetectionRadius)
            {
                MyFood = FoodAvailabal[i];
                break;
            }
        }
    }
}
