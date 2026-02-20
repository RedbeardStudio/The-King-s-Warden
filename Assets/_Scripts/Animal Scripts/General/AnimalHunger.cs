using System;
using System.Collections;
using UnityEngine;


public class AnimalHunger
{
    #region Fields
    private MonoBehaviour _coroutineStarter;
    

    public float currentSatiationValue = 200f;
    public float currentSatiationDecreaseRate = 0.3f;
    public float currentSatiationLevel;
    public float maxSatiation = 500f;
    private float eatingTimeInSecs = 3.0f;

    /*Oversatiated: >100%, Satiated: 100 - 85%, Hungry: 85 - 15%, Starving: 15 - 0%*/
    public enum HungerState { Oversatiated, Satiated, Hungry, Starving }
    public HungerState hungryState;

    // Will be set through Animal.cs by passing values from the SO
    //for now: Hard Coded values
    public float hungryThreshold = 0.15f; //above .15 -> hungry
    public float satiatedThreshold = 0.85f; // above .85 -> satiated
    public float starvingThreshold = 0f; //above 0 -> starving
    public float oversatiatedThreshold = 1f; //above 1.0 -> oversatiated

    #endregion

    public AnimalHunger(MonoBehaviour coroutineStarter)
    {
        Debug.Log("Constructor on AnimalHunger called");
        _coroutineStarter = coroutineStarter;
    }
    
    

    public HungerState GetHungryState()
    {
        return hungryState;
    }


    public void OnWorldTick(float t)
    {
        //Debug.Log($"Tick raised on AnimalHunger.");
        UpdateHungerData();

       
    }


    private void UpdateHungerData()
    {
        // Debug.Log($"Current hunger value: {currentSatiation}. in %: {Mathf.Floor(EvaluateHungerLevel() * 100)}");

       
        CalculateCurrentSatiationValue();
        CalculateSatiationLevel();
        EvaluateHungryState();

        //Debug.Log ($"Hunger Value: {currentSatiationValue}");

    }

    public void StartEating()
    {
        _coroutineStarter.StartCoroutine(Eat());
    }

    #region "Calculations & State Handling"

    private void CalculateCurrentSatiationValue()
    {
         if (currentSatiationValue >= 0)
        {
            currentSatiationValue -= currentSatiationDecreaseRate;
        }
        else
        {
            currentSatiationValue = 0f;
        }
    }

    private float CalculateSatiationLevel()
    {
        currentSatiationLevel = currentSatiationValue / maxSatiation;
        return currentSatiationLevel;
    }

    private void EvaluateHungryState()
    {
        HungerState newState = HungerState.Starving;
        
        if (currentSatiationLevel >= oversatiatedThreshold)
        {
            newState = HungerState.Oversatiated;
            
        }
        else if (currentSatiationLevel >= satiatedThreshold)
        {
            newState = HungerState.Satiated;
            
        }
        else if (currentSatiationLevel >= hungryThreshold)
        {
            newState = HungerState.Hungry;
            
        }
        else if (currentSatiationLevel >= starvingThreshold)
        {
            newState = HungerState.Starving;   
        }

        if  (newState != hungryState)
        {
            hungryState = newState;
            AnimalEvents.OnHungerStateChanged.Raise(hungryState);        
        }
    } 
    #endregion


    private IEnumerator Eat()
    {
        

        // Debug.Log("Found food: I am now " + currentState);
        yield return new WaitForSeconds(eatingTimeInSecs);

        Debug.Log("Finished Eating.");

        currentSatiationValue += 10; //TODO: Change for actual Food Value
        

        Debug.Log($"Added 10 to currentSatiation from AnimalHunger.");

        AnimalEvents.OnFinishedEatCycle.Raise(currentSatiationLevel);

        
    }

    //if isHungry => SearchFood (AnimalSenses)
    // FindNearest FoodSource (AnimalSenses)
    // move to source
    // eat, add current food objects provisional value to hunger value (Bush)
    //how to find the actual bush, the animal is on?
    //OnTriggerEnter?

}