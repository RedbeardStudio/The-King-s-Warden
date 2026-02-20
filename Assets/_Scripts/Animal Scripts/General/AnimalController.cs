using System;
using System.Collections;

using UnityEngine;

public enum AnimalActionState
{
    Moving, Eating
}


/// <summary>
/// The AnimalController class handles all movement related operations.
/// </summary>
public class AnimalController : MonoBehaviour
{

    //private bool isMoving = false;

    private float _frontExtent;
    private Vector3 destination;
    // private bool destinationReached = false;
    public Vector3 directionToTarget { get; private set; }
    [SerializeField]
    private float movementSpeed = 3f;

    [SerializeField]
    private float moveRadius = 40f;

    private bool _canMove = false;

    public float stoppingDistance = 5f;

    private Rigidbody rb;
    public Rigidbody GetRigidbodyReference()
    {
        return rb;
    }

    private Vector3 targetDirection;

    

    public bool hasDestination, isEating = false;

    private AnimalActionState currentState;

    public void SetAnimalActionState(AnimalActionState newState)
    {
        currentState = newState;
    }



    void Start()
    {

    }

    //AWAKE is called at the instanciation of the object
    private void Awake()
    {
        Debug.Log($"destination at start: {destination}");

        rb = GetComponent<Rigidbody>();
        //destination = SetRandomTargetPosition();
        //hasDestination = true;

        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;

        Renderer renderer = GetComponent<Renderer>();


    }



    //FIXED UPDATE
    private void FixedUpdate()
    {

        if (currentState != AnimalActionState.Moving)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        if (_canMove)
        {
            MoveToTarget();
        }
        

    }

    private void MoveToTarget()
    {
        //Moving to target
        Vector3 directionToTarget = (destination - rb.position).normalized; // direction to target position
        Vector3 movement = directionToTarget * movementSpeed;

        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        transform.LookAt(destination); //LookAt goes to forward vector which is z-axis

        Vector3 frontPosition = transform.position + transform.forward * _frontExtent;


        if (Vector3.Distance(frontPosition, destination) <= stoppingDistance) //offset stoppingdistance by half of the length of the mesh | if an animal reached its destination it should stop for a while and after a while proceed to do stuff.
        {
            Debug.Log("Destination reached");
            //fire event
            AnimalEvents.OnDestinationReached.Raise(destination);
            currentState = AnimalActionState.Eating;
            _canMove = false;
            destination = rb.position;
        }


    }


    public Vector3 SetRandomTargetPosition()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * moveRadius;
        randomDirection.y = 0;



        return transform.position + randomDirection;
    }

    public void WanderAround()
    {

        destination = SetRandomTargetPosition();
        Debug.Log($"destination in SetRandomTargetPosition: {destination}");
        SetCanMove(true);
        hasDestination = true;
    }


    public Vector3 SetDestination(Vector3 target
    //, float stoppingDist
    )
    {
        //stoppingDistance = stoppingDist;
        destination = target;
        return destination;
    }



    public void SetCanMove(bool value)
    {
        _canMove = value;
    }

    public void SetFrontExtent(float frontExtent)
    {
        _frontExtent = frontExtent;
    }


    #region Gizmos & Debugging
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(destination, 0.3f);
        Gizmos.DrawWireSphere(destination, stoppingDistance);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(destination, stoppingDistance + (GetComponent<Renderer>().bounds.size.z * 0.5f));

    }

    #endregion

    /*
    *Old Move method for moving randomly around - was substituted by the same method but with a v3 position in signature
    private void MoveTowardsTarget()
    {

        if (Vector3.Distance(transform.position, destination) <= stoppingDistance)
        {

            StopMoving();

            StartCoroutine(Eating());

            return;
        }

        Vector3 directionToTarget = (destination - rb.position).normalized; // direction to target position
        Vector3 movement = directionToTarget * movementSpeed;

        transform.LookAt(destination);


        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
    */



    //TODO:
    /**
    Reaarange the code here.
    At the start: let the animal check its food requirement status (for example 0/1000 eaten units -> go feeding).
    The flow shall be:
    - check foodrequirement status
    - check if current elvel is under threshold for feeding
    - go feeding on food source
    - get food units from food source
    - check food reuirement again with new level (for example now it has eaten 10/1000 food units)
    - check if that's still under threshold for only feeding
        yes: repeat feeding loop
        no: for now repeat feeding loop until requirements are met or no food sources are available.

    This will require to rename some of the Coroutines and/or methods. also it could mean to create new events.
    **/





}
