using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 5.0f;
    private int actualIndex = 0;
    private CreateZones zones;
    List<Vector3> positionsList = new List<Vector3>();

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        zones = FindObjectOfType<CreateZones>();
        positionsList = zones.zonesPositions;
    }
    private void Update()
    {
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move != Vector3.zero)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
            gameObject.transform.forward = move;
        }

        //change zone
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeZone();
        }
    }

    public void ChangeZone()
    {
        if(positionsList.Count > 0)
        {
            gameObject.transform.position = new Vector3(positionsList[actualIndex].x, 1f, positionsList[actualIndex].z);
            Debug.Log("position: " + positionsList[actualIndex].ToString());
            actualIndex = (actualIndex + 1) % positionsList.Count;
        }
    }
}
