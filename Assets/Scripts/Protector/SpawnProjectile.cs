using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void Spawn(Transform target)
    {

        GameObject projectile = Instantiate(prefab, transform.position, transform.rotation);
        projectile.GetComponent<MoveProjectile>().SetTarget(target);
    }



}
