using CustomEventBus;
using CustomEventBus.Signals;
using System;
using UnityEngine;

public class Regulator : MonoBehaviour
{
    public RegulaturState curState;

    private int stateCount;
    private RotateRegulator rotateRegulator;
    private EventBus eventBus;
    private void Start()
    {
        Initialization();
    }
    public void Initialization()
    {
        curState = RegulaturState.turnOff;
        stateCount = Enum.GetValues(typeof(RegulaturState)).Length;
        
        rotateRegulator = GetComponent<RotateRegulator>();
        eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void OnMouseOver()
    {
       if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            MoveForward();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            MoveBack();
        }
    }

    private void MoveBack()
    {
        int newID = (int)curState;
        newID--;
        CheckNewID(ref newID);
        ChangeState(newID);
    }

    private void MoveForward()
    {
        int newID = (int)curState;
        newID++;
        CheckNewID(ref newID);
        ChangeState(newID);
    }

    private void CheckNewID(ref int newID)
    {
        if (newID < 0)
        {
            newID = stateCount - 1;
        }
        if (newID == stateCount)
        {
            newID = 0;
        }
    }

    private void ChangeState(int newID)
    {
        RegulaturState newState = (RegulaturState)newID;
        curState = newState;
        rotateRegulator.RotateRegulators(newID);
        eventBus?.Invoke(new ChangedStateSignal());
    }

   

}


