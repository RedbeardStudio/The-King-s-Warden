using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public float currentHealth;
    public AnimalBrain _animalBrain {get; private set;}
    public AnimalHunger _animalHunger {get; private set;}
    public AnimalHealth _animalHealth {get; private set;}
    private AnimalController _animalController;
    
    
    
    private AnimalSenses _animalSenses;
    public AnimalSO _animalSO;



    //from ANimalState
    //Animal data variables/fields
    

 
    public void Start()
    {
        

        Debug.Log("Animal.cs/Start(): Called.");

        currentHealth = _animalSO.healthPoints;
        // currentHungerIncreaseRate = blueprintSO.hungerIncreaseRate;
        /*
        TODO:
        update SO and put actual values in it.
        
        _animalHunger.SetFoodSearchRadius(_animalSO.lookingForFoodRadius);
        _animalHunger.foodRequired = _animalSO.generalFoodRequirementAmount;
        _animalHunger.hungerThreshold = _animalSO.hungerThresholdPercent;
        _animalHunger.satiationThreshold = _animalSO.satiationThresholdPercent;
        _animalHunger.foodEaten = _animalSO.amountFoodEaten;
        */
        
    }
    public void Awake()
    {
        _animalController = GetComponent<AnimalController>();
        _animalSenses = GetComponent<AnimalSenses>(); //muss das als MonoBehaviour?

        _animalHunger = new AnimalHunger(this);
        _animalHealth = new AnimalHealth();
       // _animalSenses = new AnimalSenses();

        _animalBrain = new AnimalBrain(_animalController, _animalSenses, _animalHunger, _animalHealth);  
        

        _animalController.SetFrontExtent(_animalSO.frontExtent);
    }


    void OnDestroy()
    {
        _animalBrain.Destroy();
    }

    

    


}
