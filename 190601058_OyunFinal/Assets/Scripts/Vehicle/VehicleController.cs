using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public GameObject PlayersCar;
    public GameObject PlayersYacht;
    public GameObject PlayersAircraft;
    public GameObject AreasCar;
    public GameObject AreasYacht;
    public GameObject AreasAircraft;
    public GameObject exitCarButton;
    public GameObject exitYachtButton;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public bool isInVehicle;
    public bool isAircraftOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            PlayersCar.SetActive(true);
            AreasCar.SetActive(false);
            exitCarButton.SetActive(true);
            isInVehicle = true;

        }

        if (other.CompareTag("Yacht"))
        {
            PlayersYacht.SetActive(true);
            AreasYacht.SetActive(false);
            exitYachtButton.SetActive(true);
            isInVehicle = true;
        }

        if (other.CompareTag("Aircraft"))
        {
            PlayersAircraft.SetActive(true);
            AreasAircraft.SetActive(false);
            isInVehicle = true;
            skinnedMeshRenderer.enabled = false;
            isAircraftOn = true;
        }
    }

    public void ExitCar()
    {
        PlayersCar.SetActive(false);
        AreasCar.SetActive(true);
        this.transform.position = new Vector3(this.transform.position.x - 3, this.transform.position.y, this.transform.position.z);
        exitCarButton.SetActive(false);
        isInVehicle = false;

    }

    public void ExitYacth()
    {
        PlayersYacht.SetActive(false);
        AreasYacht.SetActive(true);
        this.transform.position = new Vector3(334, this.transform.position.y,54);
        exitYachtButton.SetActive(false);
        isInVehicle = false;
    }
}
