using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
   public GameObject objectPoolManager;
   public Camera MainCamera;
   
   EnemyPool enemyPool;

   void Start()
   {
      enemyPool = objectPoolManager.GetComponent<EnemyPool>();
   }
   void Update()
   {
      CheckEnemyVisibleInCamera();
   }

   private void CheckEnemyVisibleInCamera()
    {
      
        Plane [] frustrumPlanes = GeometryUtility.CalculateFrustumPlanes(MainCamera);
        foreach(GameObject gameObject in enemyPool.getObjectPool())
        {
           if(gameObject != null)
           {
             Bounds enemyBounds = gameObject.GetComponent<SpriteRenderer>().bounds;
            if(GeometryUtility.TestPlanesAABB(frustrumPlanes,enemyBounds))
            {
               gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
           }
        }
  
    }

   

}
