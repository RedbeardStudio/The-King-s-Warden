using System.Collections;
using UnityEngine;


public enum PlantClass {Tree, Bush, Fruit, Berry, Grains, Seed, Algae, Funghi, Fern, Moss, Mushroom}




[CreateAssetMenu(fileName = "PlantSO", menuName = "Game Assets/Environment/Plants/New Plant")]
public class PlantSO : ScriptableObject
{
    [Header("General Information")]
    [Tooltip("The plants' class - simplified.")]
    public PlantClass _plantClass;
    [Tooltip("The plants' common name.")]
    public string _name;
    [Tooltip("The plants' scientific name in latin.")]
    public string _scientificName;

    public bool _isPlant;


    [Header("Nurtition parameters")]
    [Range(0f, 1f)]
    public float _baseEdibility;

    [Range(0f, 1f)]
    public float _toxicity;

    [Range(0f, 1f)]
    public float _hardness;

    [Tooltip("How much nutrition value a plant yields.")]
    [Range(0f,500f)]
    public float _nutritionValue;
    
    [Tooltip("How much nutrition can be gained with one bite.")]
    public float _biteNutrition;

    [Tooltip("How long a bite will take.")]
    public float _biteDuration;


    [Header("Fruits & Subplants")]
    public FruitSO fruitType;
    [Tooltip("Whether or not the plant is capable of producing edible fruits.")]
    public bool _canProduceEdibleFruits;

    [Tooltip("The max capacity of fruits this plant can hold.")]
    public int _maxFruitCapacity;
    [Tooltip("The current amount of ripe fruits on the plant.")]
    private int _currentRipeFruits;
    [Tooltip("The current amount of growing fruits on the plant. Sum of growing and ripe fruits may not exceed the maxCapacity of the fruit!")]
    private int _currentGrowingFruits;


    

}
