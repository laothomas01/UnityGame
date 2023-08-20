using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : ProjectileWeapon
{
    // KnifeController kc;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        // kc = FindObjectOfType<KnifeController>();
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime; //set the movement of the knife
    }
    
}
