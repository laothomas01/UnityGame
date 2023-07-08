using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Handle the front-end and back-end for targetting game objects
/// </summary>
public class TargetSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crossHairUI;
    public GameObject weaponUI;
    public GameObject enemy;
    public float attackRange;
    Vector3 direction;
    public float offsetDistance;
    private float rotation;
    
    //@TODO later
    private GameObject currentTarget;
    void Start()
    {
        direction = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        //@TODO need to change the "enemy.transform" to a currently found target later
       
        //back-end
        rotation = Mathf.Atan2(enemy.transform.position.y - transform.position.y,enemy.transform.position.x - transform.position.x);
        direction.Set(Mathf.Cos(rotation),Mathf.Sin(rotation),0);
        // //front-end
        crossHairUI.transform.position = transform.position + direction * offsetDistance;
        

    }
    public void setCurrentTarget(GameObject target)
    {
        this.currentTarget = target;
    }
    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }
    public float getRotation()
    {
        return rotation;
    }
    public Vector3 getAngularOffset()
    {
        return direction;
    }
    public Vector3 getDirection()
    {
        return direction;
    }

    
}
