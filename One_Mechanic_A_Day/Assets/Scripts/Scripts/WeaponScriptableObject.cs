using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//define a way to create a scriptable object from this template
[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    /// <summary>
    /// Learning about creating properties
    /// </summary>
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    // public GameObject Prefab{get => prefab; private set => prefab = value;}   
    //Base stats for weapons
    [SerializeField]

    float damage;
    public float Damage { get => damage; private set => damage = value; }
    [SerializeField]

    float speed;
    public float Speed { get => speed; private set => speed = value; }
    [SerializeField]

    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => damage = value; }
    [SerializeField]

    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
