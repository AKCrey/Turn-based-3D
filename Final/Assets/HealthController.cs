using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int startingHealthpoints = 1;
    public string lethalBulletTag = "ENTER LETHAL BULLET TAG HERE";
    
    public bool isPlayerHealthController = false;
    public UnityEvent onDeathEvent;//UnityEvent is a list of methods inside of Unity! Reverse method sort off

    private int currentHealthPoints = 0;


    public int GetCurrentHealth()
    {
        return currentHealthPoints;
    }


    private void Start()
    {

        currentHealthPoints = startingHealthpoints;
    }

    public void RecieveDamage(int reduceHealthBy)
    {
        if (currentHealthPoints > 0)
        {
            currentHealthPoints -= reduceHealthBy;
        }
        if (currentHealthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //We die here

        onDeathEvent.Invoke();//Call every function that is in the list

        Destroy(this.gameObject);

    }

    private void OnTriggerEnter(Collider other) //other == what we collide with
    {
        const int DAMAGE_POINTS = 1;

        if (other.CompareTag(lethalBulletTag))
        {

            RecieveDamage(DAMAGE_POINTS);

        }

    }
}
