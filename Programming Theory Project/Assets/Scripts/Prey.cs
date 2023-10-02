using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Prey : Species // INHERITANCE
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
            Hungry = base.CheckIfHungry(CurrentEnergyLevel, EnergyToBeFed); // ABSTRACTION
            if (Hungry == true && MyFood != null)
            {
                base.MoveToFood(MyFood, transform.position); // ABSTRACTION
                if (Mathf.Abs(MyFood.transform.position.x - transform.position.x) <= 0.2)
                {
                    CurrentEnergyLevel = base.Eat(CurrentEnergyLevel, EnergyToBeFed, FoodEnergy = 10, MyFood); // ABSTRACTION
                }
            }
            else
            {
                base.Move(SpeciesSpeedMultiplicator); // ABSTRACTION
                MyFood = base.DetectFood(FoodType,FoodDetectionRadius); // ABSTRACTION
            }
            CurrentEnergyLevel = base.Hunger(CurrentEnergyLevel); // ABSTRACTION
        }
        
    }
}
