using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static Action<int, int> SendInputActions;

    int MovementForward;
    int MovementSideways;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovementForward = 1;
            OnSendInputAction();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovementForward = -1;
            OnSendInputAction();
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            MovementForward = 0;
            OnSendInputAction();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovementSideways = -1;
            OnSendInputAction();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovementSideways = 1;
            OnSendInputAction();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            MovementSideways = 0;
            OnSendInputAction();
        }
    }

    void OnSendInputAction()
    {
        SendInputActions(MovementForward, MovementSideways);
    }
}