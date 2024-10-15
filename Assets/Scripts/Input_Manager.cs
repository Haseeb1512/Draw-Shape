using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{    [SerializeField]  Camera _Camera;
Vector3 inputVector;
    private void Update()
    {
        if (Input.touchCount > 1) //Cancel Double Touch
            return;
      inputVector=_Camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            FirstTouch(inputVector);
        }
        else if (Input.GetMouseButton(0))
        {
            Static_Events.Input_.Hold?.Invoke(inputVector);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Static_Events.Input_.Up?.Invoke(inputVector);
        }
    }

    void FirstTouch(Vector3 touchVector)
    {
        Static_Events.Input_.FirstTouch?.Invoke(touchVector);
    }
}

public struct Input_Events
{
    public Action<Vector3> FirstTouch;
    public Action<Vector3> Hold;
    public Action<Vector3> Up;
}

public partial struct Static_Events
{
    public static Input_Events Input_ = new Input_Events();
}
