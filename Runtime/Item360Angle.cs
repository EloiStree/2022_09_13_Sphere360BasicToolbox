using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item360Angle
{
    public float m_horizontalLeftRight;
    public float m_verticalDownTop;
    public float m_tiltLeftRight;

    public Item360Angle()    {    }
    public Item360Angle(in Vector3 eulerRotation)
    {
        SetWithEuler(in eulerRotation);
    }
    public Item360Angle(in Quaternion rotation)
    {
        SetWithRotation(in rotation);
    }
    public Item360Angle(in Item360Angle rotation)
    {
        SetWithRotation(in rotation);
    }

    public void SetWithRotation(in Item360Angle eulerRotation)
    {
        m_verticalDownTop = -eulerRotation.m_verticalDownTop;
        m_horizontalLeftRight = eulerRotation.m_horizontalLeftRight;
        m_tiltLeftRight = -eulerRotation.m_tiltLeftRight;
    }
    public void SetWithEuler(in Vector3 eulerRotation)
    {
        m_verticalDownTop = -eulerRotation.x;
        m_horizontalLeftRight = eulerRotation.y;
        m_tiltLeftRight = -eulerRotation.z;
    }
    public void SetWithRotation(in Quaternion rotation)
    {
        Vector3 eulerRotation = rotation.eulerAngles;
        m_verticalDownTop = -eulerRotation.x;
        m_horizontalLeftRight = eulerRotation.y;
        m_tiltLeftRight = -eulerRotation.z;
    }

    public void GetAsRotation(out Quaternion localRotation)
    {
        localRotation = Quaternion.Euler(-m_verticalDownTop, m_horizontalLeftRight, -m_tiltLeftRight);
    }
}

