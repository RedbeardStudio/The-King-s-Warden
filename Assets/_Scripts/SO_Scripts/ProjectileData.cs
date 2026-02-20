using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Game Assets/Weapon/Accesoires/Projectile Data")]
public class ProjectileData : ScriptableObject
{
    public string name;
    public float projectileSpeed;
    public float projectileDamage;

    private float projectileMass { get { return 0; } }
    private float projectileDrag { get { return 0; } }

    public GameObject projectileModel;

}
