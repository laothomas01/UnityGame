using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    //check if the game object has the ICollectible interface

    //using interface reduces redundancy in code because we will be collecting more than just exp drops
   private void OnTriggerEnter2D(Collider2D col)
   {
    if(col.gameObject.TryGetComponent(out ICollectible collectible))
    {
        collectible.Collect();
    }
   }
}
