using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }
    public List<Drops> drops;

  
    void OnDestroy()
    {
        if(!gameObject.scene.isLoaded) //stops the spawning error when stopping play
        {
            return;
        }
        //randomNumber = percentage of drop, drop the item

        float randomNumber = UnityEngine.Random.Range(0f, 100f);
        //edge case: all items on a enemy will drop instead of just 1
        List<Drops> possibleDrops = new List<Drops>();
        foreach (Drops rate in drops)
        {
            if (rate.dropRate > 100)
            {
                    throw new System.Exception("Item drop rate cannot exceed 100 exception!");
            }
            if (randomNumber <= rate.dropRate)
            {
                //add all possible items that will drop
                possibleDrops.Add(rate);
            }
        }
        //Check if there are possible drops
        if (possibleDrops.Count > 0)
        {
            //choose a possible item to drop
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.itemPrefab, transform.position,drops.itemPrefab.transform.rotation);
        }

    }
}
