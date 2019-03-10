using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    private float _shootingCooldown;
    [SerializeField]
    private GameObject _fireball;
    [SerializeField]
    private Transform _fireballSpawn;

    void Start()
    {
        StartShooting();
    }


    private IEnumerator ShootingTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(_shootingCooldown);
            Shoot();
        }
    }

    private void StartShooting()
    {
        StartCoroutine(ShootingTimer());
    }

    private void Shoot()
    {
        Instantiate(_fireball, _fireballSpawn.position, transform.rotation);
    }
}
