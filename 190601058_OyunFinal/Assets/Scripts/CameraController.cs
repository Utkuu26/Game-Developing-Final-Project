using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offsetCamera = Vector3.zero;
    public VehicleController vehicleController;
    public Transform aircraftTransform;

    void Start()
    {
        offsetCamera = transform.position - playerTransform.position;
    }

    void Update()
    {

        if (!vehicleController.isInVehicle)
        {
            Vector3 newPosition = playerTransform.position + offsetCamera;

            transform.position = Vector3.Lerp(transform.position,newPosition, 0.1f);
        }

        else
        {
             if(vehicleController.isAircraftOn)
            {
                playerTransform = aircraftTransform;
                Vector3 newPosition = playerTransform.position + offsetCamera;
                transform.position = Vector3.Lerp(transform.position,newPosition, 0.1f);
            }

            else 
            {
                Vector3 newPosition = playerTransform.position + offsetCamera*2;
                transform.position = Vector3.Lerp(transform.position, newPosition, 0.1f); 
            }
        }
    }
}

