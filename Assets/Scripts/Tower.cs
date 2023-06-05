using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Radius = 10f;
    public int Damage = 5; 
    public float Speed = 1;
    public int UpgradeMultiplier = 1;
    public Transform Target;
    public GameObject Shell;
    public Transform AttackPoint;
    bool isShoot = false;
    public GameObject Sphere;
    SphereCollider rad;

    // Start is called before the first frame update
    void Start()
    {
        rad = Sphere.GetComponent<SphereCollider>();
        rad.radius = Radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShoot && Target)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isShoot= true;
        GameObject Bullet = Instantiate(Shell, AttackPoint.position, Quaternion.identity);
        Bullet.GetComponent<Shell>().target = Target;
        Bullet.GetComponent<Shell>().tower = this;
        yield return new WaitForSeconds(Speed);
        isShoot= false;
    }

    public void UpdateParametres(int lvl)
    {
        Radius += lvl * (float)0.5;
        rad.radius = Radius;
        if (Speed> 0.1)
            Speed -= (float)3.7 / lvl * (float)0.06;
        if (Speed < 0.1) Speed = (float)0.1;
        Damage += (int)(lvl * (float)1.5);
    }
}
