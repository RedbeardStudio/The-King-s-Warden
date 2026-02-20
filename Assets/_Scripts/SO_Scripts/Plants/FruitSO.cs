using System.Collections;
using UnityEngine;

public enum FruitType{Apple, Pear, Raspberry, Strawberry, Holunder, Cherry, Grapes, Plum, Peach, Leaf}
[CreateAssetMenu(fileName = "FruitSO", menuName = "Game Assets/Environment/Plants/New Fruit")]
public class FruitSO : ScriptableObject
{
    [Header("General Information")]
    public string _fruitName;
    public bool _isFruit;

    [Header("Fruit Specifics")]
    [Tooltip("How much ripeness a fruit gains per tick.")]
    [Range(0f, 0.5f)]
    public float _ripenessGainPerTick;

    [Tooltip("The current Ripeness of the fruit or subplant.")]
    [Range(0f, 1f)]
    private float _currentRipeness;


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


    

    

    [Tooltip("Time of year in which the fruit grows.")]
    public float _timeOfYearGrowingStart;
    public float _timeOfYearGrowingEnd;
}