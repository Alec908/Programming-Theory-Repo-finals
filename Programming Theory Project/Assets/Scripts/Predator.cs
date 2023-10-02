using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Predator : Species // INHERITANCE
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
        Hungry = base.CheckIfHungry(CurrentEnergyLevel, EnergyToBeFed); // ABSTRACTION
        if (Hungry == true && MyFood != null)
        {
            base.MoveToFood(MyFood, transform.position); // ABSTRACTION
            if (Mathf.Abs(MyFood.transform.position.x - transform.position.x) <= 0.2)
            {
                CurrentEnergyLevel = Eat(CurrentEnergyLevel, EnergyToBeFed, FoodEnergy = 50, MyFood);
            }
        }
        else
        {
            base.Move(SpeciesSpeedMultiplicator); // ABSTRACTION
            MyFood = base.DetectFood(FoodType, FoodDetectionRadius); // ABSTRACTION
        }
        CurrentEnergyLevel = base.Hunger(CurrentEnergyLevel); // ABSTRACTION
    }
    
    protected override int Eat(int CurrentEnergy, int EnergyToBeFed, int FoodEnergyValue, GameObject FoodObject) //POLYMORPHISM
    {
        MyFood.GetComponentInChildren<Prey>().BeingEaten = true;
        Destroy(FoodObject);
        CurrentEnergy += FoodEnergyValue;
        return CurrentEnergy;
    }
}
