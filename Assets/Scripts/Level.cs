using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField]
    GameObject[] _DetectPoints;
    GameObject _FirstPoint;
    [SerializeField] LineRenderer _DrawLineRenderer;
    private void OnEnable()
    {
        Static_Events.Input_.FirstTouch += FirstTouch;
        Static_Events.Input_.Hold += DetectNearestPoint;
    }

    private void OnDisable()
    {
        Static_Events.Input_.FirstTouch -= FirstTouch;
          Static_Events.Input_.Hold -= DetectNearestPoint;
    }
float MinDistance = 100000000f;
        float Distance = 0;
    void FirstTouch(Vector3 touchVector)
    {
       
         MinDistance = Mathf.Infinity;
         Distance = 0;
        int Length = _DetectPoints.Length;
        for (int i = 0; i < Length; i++)
        {
            Distance = Vector3.Distance( _DetectPoints[i].transform.position,touchVector);
              
            if (Distance<MinDistance)
            {
              
                _FirstPoint = _DetectPoints[i];
                   MinDistance = Distance;
            }
          
        }
    }
    void DetectNearestPoint(Vector3 touchVector)
    {
      
         MinDistance = Mathf.Infinity;
         Distance = 0;
        int Length = _DetectPoints.Length;
        for (int i = 0; i < Length; i++)
        {
            Distance = Vector3.Distance( _DetectPoints[i].transform.position,touchVector);
              
            if (Distance<MinDistance)
            {
              
                _FirstPoint = _DetectPoints[i];
                   MinDistance = Distance;
            }
          
        }
    }
}
