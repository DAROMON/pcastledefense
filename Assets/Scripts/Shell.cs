using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Shell : MonoBehaviour
{
    public float Speed =100;
    public Transform target;
    public Tower tower;

    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        }
        catch
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.gameObject.transform == target)
        {
            Destroy(gameObject);
            if (enemy.WillDie(tower.Damage))
            {
                target.tag = "Untagged";
                tower.Target = null;
            }
            enemy.TakeDamage(tower.Damage);
        }
    }
}
