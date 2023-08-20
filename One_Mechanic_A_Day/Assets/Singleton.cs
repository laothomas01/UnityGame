using UnityEngine;

/// <summary>
/// Base single class 
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)

            {
                instance = FindObjectOfType<T>();
                if(instance == null)
                {
                    GameObject gameObject = new GameObject("");
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
            
        }
    }
    private void Awake()
    {
        //make sure there is only 1 instance of this singleton
        if(instance == null)
        {
            instance = this as T;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
