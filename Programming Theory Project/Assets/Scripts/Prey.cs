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
    private GameObject NearestFood;
    private int EnergyToBeFed = 100;
    private float SpeciesSpeedMultiplicator = 1.0f;

    //Status
    private bool Hungry  = true;
    private bool FoodDetected = false;
    private int CurrentEnergy = 0;
    


    private void Start()
    {
        base.SetColor(Color);
    }

    private void Update()
    {
        Hungry = base.CheckIfHungry(CurrentEnergy, EnergyToBeFed);
        if (Hungry == true)
        {
            Move(); //Bewegen sich aber müssen noch an Food interessiert werden / laufen nicht dahin wenn sie welches sehen
            NearestFood = base.DetectFood(FoodType);
        }
    }

    protected override void Move()
    {
        base.CheckBoundry();
        transform.Translate(Vector3.forward * Movementspeed * SpeciesSpeedMultiplicator);
    }
}
