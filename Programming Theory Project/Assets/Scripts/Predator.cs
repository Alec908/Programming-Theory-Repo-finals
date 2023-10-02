using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Predator : Species
{
    //Species characteristics

    private Color Color = Color.red;
    private string FoodType = "Prey";
    private GameObject MyFood;
    private int EnergyToBeFed = 150;
    private float SpeciesSpeedMultiplicator = 1.2f;
    private float FoodDetectionRadius = 2.0f;

    //Status
    private bool Hungry = true;
    private bool FoodDetected = false;
    protected bool BeingEaten = false;
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
            base.MoveToFood(MyFood, transform.position);
            if (Mathf.Abs(MyFood.transform.position.x - transform.position.x) <= 0.2)
            {
                MyFood.GetComponentInChildren<Prey>().BeingEaten = true;
                CurrentEnergyLevel = base.Eat(CurrentEnergyLevel, EnergyToBeFed, FoodEnergyFlesh, MyFood);
                Debug.Log($"Hunted! {CurrentEnergyLevel}");
            }
        }
        else
        {
            base.Move(SpeciesSpeedMultiplicator);
            MyFood = base.DetectFood(FoodType, FoodDetectionRadius);
        }
        CurrentEnergyLevel = base.Hunger(CurrentEnergyLevel);
    }
}
