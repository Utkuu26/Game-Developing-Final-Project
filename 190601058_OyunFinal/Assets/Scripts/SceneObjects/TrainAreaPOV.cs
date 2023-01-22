using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAreaPOV : MonoBehaviour
{
    public Collider trainAreaPOV;
    public Collider normalAreaPOV;
    public GameObject normalCamera;
    public GameObject secondCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrainPov"))
        {
            normalCamera.GetComponent<Camera>().enabled = false;
            secondCamera.GetComponent<Camera>().enabled = true;
            trainAreaPOV.enabled = false;
            normalAreaPOV.enabled = true;
        }

        if (other.CompareTag("NormalPov"))
        {
            normalCamera.GetComponent<Camera>().enabled = true;
            secondCamera.GetComponent<Camera>().enabled = false;
            trainAreaPOV.enabled = true;
            normalAreaPOV.enabled = false;
        }
    }
}
