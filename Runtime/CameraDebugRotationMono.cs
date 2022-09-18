using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraDebugRotationMono : MonoBehaviour
{

    public Transform m_originCoordinate;
    public Transform m_anchorToMove;

    public Item360Angle m_angleToApply;

    public float m_horizontalMaxAngle = 180;
    public float m_verticalMaxAngle = 90;
    public float m_tiltMaxAngle = 120;

    public void SetCorrection(Item360Angle newCorrection)
    {

        m_anchorToMove.rotation =  Quaternion.Euler(-newCorrection.m_verticalDownTop, newCorrection.m_horizontalLeftRight, -newCorrection.m_tiltLeftRight)* m_originCoordinate.rotation;
    }

    public void OnValidate()
    {
        ClampCheck();
        SetCorrection(m_angleToApply);
    }

    internal void AddHorizontal(float degree)
    {
        SetHorizontalAngle(m_angleToApply.m_horizontalLeftRight + degree);
    }

    internal void AddVertical(float degree)
    {
        SetVerticalAngle(m_angleToApply.m_verticalDownTop + degree);
    }

    internal void AddTilt(float degree)
    {
        SetTiltAngle(m_angleToApply.m_tiltLeftRight + degree);
    }

    private void ClampCheck()
    {
        m_angleToApply.m_horizontalLeftRight = Mathf.Clamp(m_angleToApply.m_horizontalLeftRight, -m_horizontalMaxAngle, m_horizontalMaxAngle);
        m_angleToApply.m_verticalDownTop = Mathf.Clamp(m_angleToApply.m_verticalDownTop, -m_verticalMaxAngle, m_verticalMaxAngle);
        m_angleToApply.m_tiltLeftRight = Mathf.Clamp(m_angleToApply.m_tiltLeftRight, -m_tiltMaxAngle, m_tiltMaxAngle);
    }
    public void ResetToForward() {
        SetPositionWithAngle(0, 0, 0);
    }

    public void SetPositionWithAngle(float horizontal, float vertical, float tilt)
    {
        SetHorizontalAngle(horizontal);
        SetVerticalAngle(vertical);
        SetTiltAngle(tilt);
    }
    public void SetPositionWithPercent(float horizontal, float vertical, float tilt)
    {
        SetHorizontalWithPercent(horizontal);
        SetVerticalWithPercent(vertical);
        SetTiltWithPercent(tilt);
    }
    public void SetHorizontalWithPercent(float percent) => SetHorizontalAngle(percent * m_horizontalMaxAngle);
    public void SetVerticalWithPercent(float percent) => SetVerticalAngle(percent * m_verticalMaxAngle);
    public void SetTiltWithPercent(float percent) => SetTiltAngle(percent * m_tiltMaxAngle);

    public void SetHorizontalAngle(float angleInDegree)
    {
        angleInDegree = Mathf.Clamp(angleInDegree, -m_horizontalMaxAngle, m_horizontalMaxAngle);
        m_angleToApply.m_horizontalLeftRight = angleInDegree;
        SetCorrection(m_angleToApply);
    }
    public void SetVerticalAngle(float angleInDegree)
    {
        angleInDegree = Mathf.Clamp(angleInDegree, -m_verticalMaxAngle, m_verticalMaxAngle);
        m_angleToApply.m_verticalDownTop = angleInDegree;
        SetCorrection(m_angleToApply);
    }
    public void SetTiltAngle(float angleInDegree)
    {
        angleInDegree = Mathf.Clamp(angleInDegree , - m_tiltMaxAngle, m_tiltMaxAngle);
        m_angleToApply.m_tiltLeftRight = angleInDegree;
        SetCorrection(m_angleToApply);
    }

}

