using System;
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
    public bool BeingEaten = false;
    private int CurrentEnergyLevel = 0;
    private float DistanceCheck = Mathf.Infinity;
    


    private void Start()
    {
        base.SetColor(Color);
    }

    private void Update()
    {
        if (BeingEaten == false)
        {
            Hungry = base.CheckIfHungry(CurrentEnergyLevel, EnergyToBeFed);
            if (Hungry == true && MyFood != null)
            {
                base.MoveToFood(MyFood, transform.position);
                if (Mathf.Abs(MyFood.transform.position.x - transform.position.x) <= 0.2)
                {
                    CurrentEnergyLevel = base.Eat(CurrentEnergyLevel, EnergyToBeFed, FoodEnergyGras, MyFood);
                }
            }
            else
            {
                base.Move(SpeciesSpeedMultiplicator);
                MyFood = base.DetectFood(FoodType,FoodDetectionRadius);
            }
            CurrentEnergyLevel = base.Hunger(CurrentEnergyLevel);
        }
        
    }
}
