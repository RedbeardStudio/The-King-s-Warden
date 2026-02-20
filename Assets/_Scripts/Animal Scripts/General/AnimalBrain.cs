using UnityEngine;

public class AnimalBrain
{
    private readonly AnimalController _animalController;
    private readonly AnimalSenses _animalSenses;
    private readonly AnimalHunger _animalHunger;
    private readonly AnimalHealth _animalHealth;



    public AnimalBrain(AnimalController controller,
                        AnimalSenses animalSenses,
                            AnimalHunger animalHunger,
                                AnimalHealth animalHealth)
    {
        _animalController = controller;
        _animalSenses = animalSenses;
        _animalHunger = animalHunger;
        _animalHealth = animalHealth;

        SubscribeEvents();


        //Debug.Log($"AnimalHunger in Brain: {_animalHunger}");

    }

    #region "Event Handling"
    private void SubscribeEvents()
    {
        //WORLD EVENTS
        WorldEvents.OnTick.Subscribe(OnTick);

        //ANIMAL EVENTS
        AnimalEvents.OnHungerStateChanged.Subscribe(OnHungerStateChanged);
        AnimalEvents.OnDestinationReached.Subscribe(OnDestinationReached);
        AnimalEvents.OnFinishedEatCycle.Subscribe(OnFinishedEatCycle);

        Debug.Log("Successfully subscribed all events.");
    }

    private void UnsubscribeEvents()
    {
        //WORLD EVENTS
        WorldEvents.OnTick.Unsubscribe(OnTick);

        //ANIMAL EVENTS
        AnimalEvents.OnHungerStateChanged.Unsubscribe(OnHungerStateChanged);
        AnimalEvents.OnDestinationReached.Unsubscribe(OnDestinationReached);
        AnimalEvents.OnFinishedEatCycle.Unsubscribe(OnFinishedEatCycle);


        Debug.Log("Successfully unsubscribed all events.");
    }

    private void OnTick(float time)
    {
        //Debug.Log($"Brain heard Tick on: {time}");
        //Update Needs
        _animalHunger.OnWorldTick(time);
        _animalSenses.OnWorldTick(1f, "Food");
        //DecideActions
        DecideActions();

        //gibt basically einfach die TickZeit weiter an andere Systeme
    }
    #endregion


    #region "Logic"

    private void DecideActions()
    {
        //Decide what to do next
    }


    private void SearchFood(float searchRadiusMultiplier)
    {
        //_controller.SetDestination(_animalSenses.FindNearestEdibleFoodSource("Food"), 1.2f);

    }


    private void OnFinishedEatCycle(float currentSatiationLevel)
    {
        Debug.Log("Finished Eating!");
    }


    private void OnDestinationReached(Vector3 someVector)
    {
        Debug.Log($"AnimalBrain says: Destination Reached!: {_animalController.GetRigidbodyReference().position}");
        // _animalController.SetDestination(SetRandomTargetPosition()); //needs return Value! SetRandomTargetPosition returns a Vetor3
        _animalHunger.StartEating();

    }

    private void OnHungerStateChanged(AnimalHunger.HungerState hungerState)
    {
        Vector3 nearestFood = Vector3.zero;
        //Do something when the hunger state changes
        Debug.Log("HungerState has changed. Event was fired.");

        switch (hungerState)
        {
            case AnimalHunger.HungerState
    .Starving:
                Debug.Log("I'm starving!");
                nearestFood = _animalSenses.FindNearestEdibleFoodSource(2f, "Food"); //find food //FIX: NullReference Exception (06.02.26)
                _animalController.SetCanMove(true);
                _animalController.SetDestination(nearestFood); //move to food
                break;

            case AnimalHunger.HungerState
    .Hungry:
                Debug.Log("I'm hungry!");
                nearestFood = _animalSenses.FindNearestEdibleFoodSource(1f, "Food"); //find food
                _animalController.SetCanMove(true);
                _animalController.SetDestination(nearestFood); //move to food

                break;

            case AnimalHunger.HungerState
    .Satiated:
                Debug.Log("I'm satiated!");
                nearestFood = _animalSenses.FindNearestEdibleFoodSource(0.15f, "Food"); //find food
                _animalController.SetDestination(nearestFood); //move to food
                break;

            case AnimalHunger.HungerState
    .Oversatiated:
                _animalController.WanderAround();
                nearestFood = _animalSenses.FindNearestEdibleFoodSource(2f, "Food"); //find food
                _animalController.SetRandomTargetPosition(); //move
                Debug.Log("I'm full!");
                break;

            default:
                Debug.Log("Default Case");
                break;
        }
    }
    #endregion


    public void Destroy()
    {
        if (this != null)
        {
            UnsubscribeEvents();

        }
    }

    /* TODO: change to something with if statements, 
        since there must be the possibility to factor in stuff like fear, 
        reproduction drive, etc...

        void DecideHungerAction()
        {
            switch (hungerState)
            {
                case HungerState
        .Starving:
                    SearchFood(2f);
                    break;

                case HungerState
        .Hungry:
                    SearchFood(1f);
                    break;

                case HungerState
        .Satiated:
                    SearchFood(.15f);
                    break;

                case HungerState
        .Oversatiated:
                   // _controller.WanderAround();
                    break;

                default:
                    SearchFood(1f);
                    break;
            }
        }*/


}
