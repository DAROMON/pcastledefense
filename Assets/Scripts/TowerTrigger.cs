using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class TowerTrigger : MonoBehaviour
{
    Transform curEn;
    public Tower Tower;
    SphereCollider sphereCollider;
    Transform Zone;
    // Start is called before the first frame update
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        Zone = GetComponent<Transform>();
    }
    private void Update()
    {
        if (!Tower.Target)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy"); // find all objects with tag "Enemy"
            foreach (GameObject go in gameObjects) // loop through the array
            {
                Vector3 closestPoint = sphereCollider.ClosestPoint(go.transform.position); // find the closest point on the sphere collider to the object position
                float distance = Vector3.Distance(Zone.position, go.transform.position); // calculate the distance between the closest point and the object position
                if (distance < sphereCollider.radius) // check if the distance is very small (you can adjust this threshold as needed)
                {
                    Tower.Target = go.gameObject.transform;
                    curEn = go.gameObject.transform;
                    break;
                }
            }
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Tower.Target = other.gameObject.transform;
            curEn = other.gameObject.transform;
        }
    }*/
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") == curEn)
        {
            Tower.Target = null;
            curEn = null;
        }
    }
}
