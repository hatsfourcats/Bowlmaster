﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    private Pin[] pinArray;
    private bool ballEnteredBox = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;


    public GameObject pinsPrefab;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    // look at level manager to figure out what i need to do to get button to see this setting static didn't fly

    public int CountStanding()
    {
        int standingPinCount = 0;

        foreach (Pin pin in GetPinArray())
        {

            if (pin.IsStanding()) { standingPinCount++; }
        }
        return standingPinCount;
    }


    public void CheckPinsSettled()
    {
        int currentStandingCount = CountStanding();

        if (currentStandingCount != lastStandingCount)
        {

        }

    }



    public void RefreshPins()
    {

        Instantiate(pinsPrefab, new Vector3(0, 2, 0), Quaternion.identity);

    }

    public Pin[] GetPinArray()
    {
        pinArray = GameObject.FindObjectsOfType<Pin>();
        return pinArray;

    }
    public void RaisePins()
    {

        foreach (Pin pin in GetPinArray())
        {

            if (pin.IsStanding()) { pin.Raise(); }
        }


    }
    public void LowerPins()
    {
        Debug.Log("Lower pins called from pinhandler");
        foreach (Pin pin in GetPinArray())
        {
            pin.Lower();
        }


    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballEnteredBox = true;
        }
    }



    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Pin_Collider")
        {
            Debug.Log("pin left collider it should destroy");
            Destroy(collider.transform.parent.gameObject);
        }
    }




}
