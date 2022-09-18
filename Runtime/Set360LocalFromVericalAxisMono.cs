using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set360LocalFromVericalAxisMono : MonoBehaviour
{
    public Transform m_root;
    public Transform m_toRotate;
    public Item360Angle m_localAnglePosition;




    public void RefreshPosition()
    {

        if (m_root != null && m_toRotate != null)
        {
            Vector3 directionFromAxis = m_root.InverseTransformPoint(m_toRotate.position);
            directionFromAxis.y = 0;
            Vector3 directionFromAxisWorldPoint = m_root.TransformPoint(directionFromAxis);
            Quaternion  direction = Quaternion.LookRotation( directionFromAxisWorldPoint - m_root.position, m_root.up);


            Quaternion rotation = direction* Quaternion.Euler(
            -m_localAnglePosition.m_verticalDownTop,
            m_localAnglePosition.m_horizontalLeftRight,
            -m_localAnglePosition.m_tiltLeftRight);
            m_toRotate.rotation = rotation;

        }   
    }

    public void Update()
    {
        RefreshPosition();
    }
    private void OnValidate()
    {
        RefreshPosition();  
    }
}
