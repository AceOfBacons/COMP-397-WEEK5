using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{

    public Transform spawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //reference to the player's character controller
            var controller = other.GetComponent<CharacterController>();

            //turn off controller
            controller.enabled = false;

            //move player player to spawn point
            other.gameObject.transform.position = spawnPoint.position;
            controller.enabled = true;
        }
    }
}
