using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float minDistance = 0.5f; 
    private Vector3 targetPosition;
    public Vector3 min;
    public Vector3 max;
    public GameObject player;
    public float radius = 1f;

    private void Start()
    {
        // Set initial target position
        SetRandomTargetPosition();

        //Set player reference
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if reached the target position, then set a new random target
        if (Vector3.Distance(transform.position, targetPosition) < minDistance)
        {
            SetRandomTargetPosition();
        }

        NearPlayer();
    }

    public void SetRandomTargetPosition()
    {
        float randomX = Random.value;
        float randomZ = Random.value;

        float targetX = Mathf.Lerp(min.x, max.x, randomX);
        float targetZ = Mathf.Lerp(min.z, max.z, randomZ);

        // Set the new target position
        targetPosition = new Vector3(targetX, 1f, targetZ);
    }

    public void NearPlayer()
    {
        //if player is near this enemy destroy the enemy
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
                Destroy(this.gameObject);
        }
    }
}
