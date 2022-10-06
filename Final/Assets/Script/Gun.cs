using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newProjectile = Instantiate(bulletPrefab);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<BulletMover>().Initialize();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject newProjectile = Instantiate(bubblePrefab);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<BulletMover>().Initialize();
        }
    }
    /*
    public int powerUpLevelRequireMent = 0;

    public BulletMover bullet;
    Vector3 direction;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.localRotation * Vector3.forward).normalized;
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        BulletMover goBullet = go.GetComponent<BulletMover>();
        goBullet.direction = direction;
    }*/
}
