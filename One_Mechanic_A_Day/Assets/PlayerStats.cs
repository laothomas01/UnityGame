using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerScriptableObjects playerData;

    //Current stats
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]

    public float currentRecovery;

    public float currentMoveSpeed;
    [HideInInspector]

    public float currentMight;
    [HideInInspector]

    public float currentProjectileSpeed;

    /// <summary>
    /// Advanced leveling system
    /// 
    /// </summary>

    //Experience and level of the player
    [Header("Experience/level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;


    // Class for defining a level range and the coresponding experience cap increase for that range
    [System.Serializable]  // system.serializable allows class to be serialized by unity: fields are visible & editable in inspector & can be saved & loaded from files

    //can this be a struct rather than a class??? 

    //each range of levels will have a certain amount of exp to be gained
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    //I-Frames
    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;



    public List<LevelRange> levelRanges;

    InventoryManager inventory;
    public int weaponIndex; // tracks index for weapons
    public int passiveItemIndex; // tracks index for passive items

    public GameObject secondWeaponTest;
    void Start()
    {
        //Initialize the experience cap as the first experience cap increase
        experienceCap = levelRanges[0].experienceCapIncrease;
    }
    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        //if the invincibility timer has reached 0, set the invincibility flag to false
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }
    //checks if the player's experience = experience cap
    void LevelUpChecker()
    {
        //increase experienceCap based on the current level range
        if (experience >= experienceCap)
        {
            level++;
            //reduce experience by experience cap
            experience -= experienceCap;
            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                //if current level between the range of a min and max level, set the experience cap
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    void Awake()
    {

        inventory = GetComponent<InventoryManager>();
        //Assign variables
        currentHealth = playerData.MaxHealth;
        currentRecovery = playerData.Recovery;
        currentMoveSpeed = playerData.MoveSpeed;
        currentMight = playerData.Might;
        currentProjectileSpeed = playerData.ProjectileSpeed;
        //Spawn the starting weapon
        SpawnWeapon(playerData.StartingWeapon);
        // SpawnWeapon(secondWeaponTest);
    }
    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;
            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            if (currentHealth <= 0)
            {
                Kill();
            }
        }

    }
    public void Kill()
    {
        Debug.Log("You have died!");
    }
    public void SpawnWeapon(GameObject weapon)
    {
        //Check if the slots are full and return if it is
        if (weaponIndex >= inventory.weaponSlots.Count - 1)
        {
            Debug.LogError("Inventory slots already full");
        }
        //Spawn the starting weapon
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform); // Set the weapon as the child of the player
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>()); // add the weapon to its inventory slot
        weaponIndex++; 
    }



}
