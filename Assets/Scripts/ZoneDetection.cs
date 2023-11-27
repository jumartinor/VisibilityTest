using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    public bool PlayerIsInside = false;
    public List<GameObject> enemiesList = new List<GameObject>();

    public int zoneId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MyZone enemyZone = other.GetComponent<MyZone>();
            if(enemyZone.currentZone != zoneId)
            {
                if(enemyZone.currentZone != -1)
                {
                    enemyZone.zone.enemiesList.Remove(other.gameObject);
                }
                enemyZone.currentZone = zoneId;
                enemyZone.zone = this;
                enemiesList.Add(other.gameObject);
            }
            other.GetComponent<Renderer>().enabled = PlayerIsInside;
        }

        if (other.CompareTag("Player"))
        {
            MyZone playerZone = other.GetComponent<MyZone>();
            if (playerZone.currentZone != zoneId) 
            {
                playerZone.zone.HideEnemies();
                playerZone.zone.PlayerIsInside = false;
                playerZone.currentZone = zoneId;
                playerZone.zone = this;
                playerZone.zone.ShowEnemies();
                PlayerIsInside = true;
            }
            else
            {
                playerZone.zone.ShowEnemies();
            }
        }
    }

    public void ShowEnemies()
    {
        for (int enemy = 0; enemy < enemiesList.Count; enemy++)
        {
            if (enemiesList[enemy] != null)
            {
                enemiesList[enemy].GetComponent<Renderer>().enabled = true;
            }
        }
    }

    public void HideEnemies()
    {
        for (int enemy = 0; enemy < enemiesList.Count; enemy++)
        {
            if (enemiesList[enemy] != null)
            {
                enemiesList[enemy].GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
