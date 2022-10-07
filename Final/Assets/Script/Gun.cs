using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private Transform shootingStartPosition;
    public float shootForce;
    public float spread;

    [SerializeField] private Camera cam;
    [SerializeField] Transform bulletSpawnPoint;

    private void Update()
    {
        MyInput();
    }
    
    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Find position using raycast
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Ray through the middle of your screen
            RaycastHit hit;

            //check if ray hits something
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(75); //Just a point far away from the player
            }

            //calculate direction from spawnpoint to targetpoint
            Vector3 directionWithoutSpread = targetPoint - bulletSpawnPoint.position;

            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

            GameObject newProjectile = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            newProjectile.transform.forward = directionWithSpread.normalized;
            //newProjectile.transform.position = shootingStartPosition.position;

            //newProjectile.GetComponent<BulletMover>().Initialize();

            //Add forces to bullet
            newProjectile.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            //newProjectile.GetComponent<Rigidbody>().AddForce(cam.transform.up, ForceMode.Impulse);


        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Find position using raycast
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Ray through the middle of your screen
            RaycastHit hit;

            //check if ray hits something
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(75); //Just a point far away from the player
            }

            //calculate direction from spawnpoint to targetpoint
            Vector3 directionWithoutSpread = targetPoint - bulletSpawnPoint.position;

            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

            GameObject newProjectile = Instantiate(bubblePrefab, bulletSpawnPoint.position, Quaternion.identity);

            newProjectile.transform.forward = directionWithSpread.normalized;
            //newProjectile.transform.position = shootingStartPosition.position;

            //newProjectile.GetComponent<BulletMover>().Initialize();

            //Add forces to bullet
            //newProjectile.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            newProjectile.GetComponent<Rigidbody>().AddForce(cam.transform.up, ForceMode.Impulse);


            /*GameObject newProjectile = Instantiate(bubblePrefab, bulletSpawnPoint.position, Quaternion.identity);
            newProjectile.transform.position = shootingStartPosition.position;
            newProjectile.GetComponent<BulletMover>().Initialize();*/
        }
    }
}
