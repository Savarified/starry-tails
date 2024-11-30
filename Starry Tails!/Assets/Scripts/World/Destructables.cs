using UnityEngine;

public class Destructables : MonoBehaviour
{
    public int maxObjects;
    void FixedUpdate()
    {
        if (transform.childCount > maxObjects){
            Destroy(transform.GetChild(0).gameObject);
        }
        
    }
}
