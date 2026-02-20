using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimalType
{
   Mammal, Reptile, Bird, Fish, Insect, Amphibian, Arachnid, Crustaceans
}

public enum sizeCategory
{
    Tiny,
    Small,
    Medium,
    Large
 }

public enum Threat
{
    None,
    Low,
    Medium,
    High,
    Extreme
 }

 public enum ConsumerType
 {
    Herbivore,
    Carnivore,
    Omnivore,
    Scavenger
 }

 public enum HerdType
 {
    None,
    Herd,
    Pack,
    Flock,
    School,
    Flink,
    Swarm,
    Pride,
    Colony,
    Pod,
    Troop,
    Gaggle,
    Parliament,
    Huddle,
    Flight,
    Sloth

 }

 public enum LocomotionType
 {
    Ground,
    Water,
    Air,
    Amphibious,
    Underground
 }

 public enum EscapePattern 
 {
    ZigZag,
    Direct,
    Random
 }




[CreateAssetMenu(menuName = "Game Assets/NPC/Animal/Animal Data")]
public class AnimalSO : ScriptableObject
{
    [Header("General Information")]
    public AnimalType speciesName;
    public string information;
    public float age_in_years;
    public float maxLifespan;
    public bool isJuvenile;
    public float weightInKgs;
    public float healthPoints;
    public bool isDomesticated;
    public bool isSick;
    public sizeCategory sizeCategory;

    public float frontExtent;

    [Header("Gameplay Information")]
    public int experience;
    public int money;
    public Threat threatlevel;
    public bool isQuestTarget;
    public bool isTameable;
    public int trophyScore;
   
    public string taggingID;

    [Header("Food & Hunting behaviour")]
    
    
    public float lookingForFoodRadius;
    public float feedingCooldown; //wie oft wird gegessen (bspw. alle 5 Minuten)
                                  // [Tooltip("How much food an animal will take from a food source per feeding round.")]
                                  //  public int foodIntakePerCycle; //-> is depnedet of food source how much intake an animal can have 
  public int generalFoodRequirementAmount;
   public int amountFoodEaten;
   [Range(0, 100)]
    [Tooltip("The threshold for when an animal isn't hungry anymore. It may consider other things than eating.")]
    public int hungerThresholdPercent;
    [Range(0, 100)]
    [Tooltip("The threshold for when an animal is satiated. It will then do other things like mate, rest, ...")]
    public int satiationThresholdPercent;
    [Tooltip("The amount of food an animal needs to fulfill to keep on living.")]
    
    //public float hungerIncreaseRate;
    public bool isScavenger; //Aasfresser
    public bool isPredator; //Jaeger
    public float ambushTendency;
    public bool isPackHunting;
    public bool isFoodSharing;

    [Header("Reproduction & Mating behaviour")]
    public int reproductiveSeasonStart; //month
    public int reproductiveSeasonEnd; //month
    public float gestationTime; //days, Schwangerschaft
    public Vector2Int offspringCountRange; //bspw. (2, 8) -> 2-8 Jungtiere
    public float matingAggression;
    public bool canMate; //Geschlechtsreife erreicht
    public float parentalCareDuration; //Nachwuchsbetreuung, days
    public bool requiresMateCall;
    public bool isPolygamous;

    [Header("Herding & Pack behaviour")]
    public bool isSocial;
    public HerdType herdType;
    public float cohesionFactor;
    public float separationDistance;
    public float herdAlignmentFactor; //wie stark die Tiere, der Bewegung der Herde folgen (Elefnaten: sehr strikt, Schafe evtl. eher nicht so)
    public bool followAlpha;
    public bool isAlpha;
    public bool seasonalGrouping;
    public Vector2Int preferredGroupSize;
    public float groupCommunicationRange;
    public float groupDefenseTriggerRadius; //bspw. für Büffel, die gemeinsam verteidigen

    [Header("Agreesion behaivour")]
    public float aggressionLevel; //[0..1]
    //public List<enum> agrressionTriggers; //needs further investigation
    public float territorailRange;
    public float attackCooldown;
    public bool willAttackHumans;
    public float alphaAggressionModifier;
    public float warningSignalDuration; //in seconds
    public bool willDefendOffspring;
    public float aggressionDecayRate;
    public List<AnimalType> targetPriority; 

    [Header("Movement behaviour")]
    public LocomotionType locomotionType;
    public float maxSpeed;
    public float acceleration;
    public float turnSpeed;
    public float jumpHeight;
    public float stamina;
    public List<string> preferredTerrain;
    public bool canClimb;
    public bool canSwim;
    public Vector2 flyingAltitudeRange;

    [Header("Fleeing behaviour")]
    public float fearThreshold; //[0..1]
    public float fleeSpeedMultiplier;
    public bool canHide;
    public float hideSpotSearchRadius;
    public float dangerMemoryTime; //Wie lang wird GEfahr im Kopf behalten
    public EscapePattern escapePattern;
    public float threatDetectionRange;
    public float startleChance; //wie schnell erschreckt sich das Tier (Rehe: sehr schnell, Bär: eher nicht so schnell)
    public bool willFleeInGroupSync;
    public float freezeChance; //ob das Tier freezed, statt weg zu laufen

}
