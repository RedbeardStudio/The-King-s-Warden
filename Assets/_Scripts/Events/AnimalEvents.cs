using UnityEngine;

public static class AnimalEvents
{
    public static GameEvent<Vector3> OnMoveToTarget = new();

    public static GameEvent<AnimalHunger.HungerState> OnHungerStateChanged = new();


    public static GameEvent<Vector3> OnDestinationReached = new();

    public static GameEvent<float> OnFinishedEatCycle = new();

}
