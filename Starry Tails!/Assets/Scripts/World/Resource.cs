using UnityEngine;

public class Resource : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            GameObject particle = GameObject.Find("resource_collect");
            Transform destruct = GameObject.Find("destructables").transform;
            GameObject temp_particle = Instantiate(particle, transform.position, Quaternion.identity);
            temp_particle.transform.SetParent(destruct);
            this.gameObject.SetActive(false);
        }
    }

}
