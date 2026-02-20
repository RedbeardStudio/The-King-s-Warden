using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimalSenses : MonoBehaviour
{

    public Transform lookingForFoodCenter;
    private Collider[] _currentFood = new Collider[0];

    private int foodSourceLayerIndex;
    private float foodSearchRadius = 20f;
    Vector3 nearestFoodPosition = Vector3.zero;
    [SerializeField]
    int collidersLength = 0;
    // Start is called before the first frame update
    void Start()
    {
        foodSourceLayerIndex = LayerMask.NameToLayer("Food");
        _currentFood = FindFood(1f, "Food");

    }





    // Update is called once per frame
    void Update()
    {

    }

    #region "Event Handling"

    public void OnWorldTick(float searchRadMultiplier, string foodLayerName)
    {
        UpdateFoodSources(searchRadMultiplier, foodLayerName);
    }
    private void UpdateFoodSources(float searchRadiusMultiplier, string foodLayerName)
    {
        _currentFood = FindFood(searchRadiusMultiplier, foodLayerName);
    }

    #endregion

    #region MainLogic

    public Vector3 FindNearestEdibleFoodSource(float srMultiplier, string foodLayerName)
    {
        //Debug.Log("In FindNearestEdibleFoodSource()");
        string nearestFoodName = "";

        Collider[] colliders = FindFood(srMultiplier, foodLayerName);

        foreach (Collider c in colliders)
        {
            Debug.Log($"c Position: {c.transform.position}");
            Debug.Log($"c.name = {c.name}");

            /*
            - get the correct type (Vector3) out of c
                c.transform.position maybe  
            - check distance to c by transform.position - c.position
            - store in nearestFoodPosition -> is correct for first object
            - check if nearestFoodPosition's Distance is greater than c's distance
                yes: nearestFoodPosition = c -> c is new nearestFoodPosition
            */

            Vector3 cPosition = c.transform.position;
            float cDistance = Vector3.Distance(lookingForFoodCenter.position, cPosition);

            if (cDistance <= Vector3.Distance(lookingForFoodCenter.position, nearestFoodPosition))
            {
                nearestFoodPosition = c.transform.position;
                //Debug.Log($"c.name = {c.name}");
                nearestFoodName = c.name;
            }


            //CheckFoodType(c);


        }
        //Debug.Log($"Moving to: " + nearestFoodName);

        return nearestFoodPosition;
    }
    #endregion

    #region HelperMethods
    Collider[] FindFood(float searchRadiusMultiplier, string foodLayerName)
    {
        //Debug.Log("In FindFood()");

        foodSourceLayerIndex = LayerMask.NameToLayer(foodLayerName);
        //Debug.Log($"foodSourceLayerIndex: {foodSourceLayerIndex}");
        int foodLayer = (1 << foodSourceLayerIndex); //Bitshift-left, gets only layer number 10 as layermask.
        foodSearchRadius *= searchRadiusMultiplier;
        Collider[] foodColliders = Physics.OverlapSphere(lookingForFoodCenter.position, foodSearchRadius, foodLayer);
        collidersLength = foodColliders.Length;
        //Debug.Log("foodColliders length: " + foodColliders.Length);


        return foodColliders;
    }



    #endregion





    #region Gizmos & Debugging

    public void OnDrawGizmos()
    {
        if (lookingForFoodCenter == null) return;
        //Search radius
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(lookingForFoodCenter.position, foodSearchRadius);
        if(_currentFood == null)
        {
            _currentFood = new Collider[0];
        } 
        foreach (Collider c in _currentFood)
        {
            Gizmos.DrawLine(lookingForFoodCenter.position, c.transform.position);
        }

        //Lines to Food
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(lookingForFoodCenter.position, nearestFoodPosition);

    }
    #endregion
}
