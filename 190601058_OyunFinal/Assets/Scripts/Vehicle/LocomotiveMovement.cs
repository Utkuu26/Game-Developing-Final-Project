using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;
using TMPro;

public class LocomotiveMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 0.05f;
    public float startTime = 0;
    float timeTravelled = 0;

    void Start()
    {
        if (pathCreator != null)
        {
            pathCreator.pathUpdated += OnPathChanged;
            timeTravelled = startTime;
        }
    }

    void Update()
    {
        if (pathCreator != null)
        {

            timeTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtTime(timeTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotation(timeTravelled, endOfPathInstruction);
        }
      
    }

    void OnPathChanged()
    {
        //distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
    public float GetCurrentTimeTravelled()
    {
        return timeTravelled;
    }

    public void StopMovement()
    {
        speed = 0;
    }

    public void StartMovement()
    {
        speed = 0.05f;
    }


}
