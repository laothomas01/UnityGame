using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats player; // allows all passive items to modify player stats
    public PassiveItemScriptableObject passiveItemData;

    protected virtual void ApplyModifier()
    {
        //Apply the boost value to the appropriate stat in the child classes
    }
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }

}
