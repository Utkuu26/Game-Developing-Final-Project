using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrainMovementControl : MonoBehaviour
{
    public LocomotiveMovement locomotive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StopTrain"))
        {
            locomotive.StopMovement();

        }

        if (other.CompareTag("StartTrain"))
        {
            locomotive.StartMovement();
        }
    }
}
