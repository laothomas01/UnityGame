using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Passive item example
/// </summary>
public class WingsPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        //used to modifier player's move speed based on a certain modifier
        //final move speed = initial move speed * 1 + multiplier percentage
        player.currentMoveSpeed *= 1 + passiveItemData.Multiplier / 100f;
    }
}
