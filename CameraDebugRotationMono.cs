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

        m_anchorToMove.rotation =  Quaternion.Euler(-newCorrection.m_vertical, newCorrection.m_horizontal, -newCorrection.m_tilt)* m_originCoordinate.rotation;
    }

    public void OnValidate()
    {
        ClampCheck();
        SetCorrection(m_angleToApply);
    }

    internal void AddHorizontal(float degree)
    {
        SetHorizontalAngle(m_angleToApply.m_horizontal + degree);
    }

    internal void AddVertical(float degree)
    {
        SetVerticalAngle(m_angleToApply.m_vertical + degree);
    }

    internal void AddTilt(float degree)
    {
        SetTiltAngle(m_angleToApply.m_tilt + degree);
    }

    private void ClampCheck()
    {
        m_angleToApply.m_horizontal = Mathf.Clamp(m_angleToApply.m_horizontal, -m_horizontalMaxAngle, m_horizontalMaxAngle);
        m_angleToApply.m_vertical = Mathf.Clamp(m_angleToApply.m_vertical, -m_verticalMaxAngle, m_verticalMaxAngle);
        m_angleToApply.m_tilt = Mathf.Clamp(m_angleToApply.m_tilt, -m_tiltMaxAngle, m_tiltMaxAngle);
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
        m_angleToApply.m_horizontal = angleInDegree;
        SetCorrection(m_angleToApply);
    }
    public void SetVerticalAngle(float angleInDegree)
    {
        angleInDegree = Mathf.Clamp(angleInDegree, -m_verticalMaxAngle, m_verticalMaxAngle);
        m_angleToApply.m_vertical = angleInDegree;
        SetCorrection(m_angleToApply);
    }
    public void SetTiltAngle(float angleInDegree)
    {
        angleInDegree = Mathf.Clamp(angleInDegree , - m_tiltMaxAngle, m_tiltMaxAngle);
        m_angleToApply.m_tilt = angleInDegree;
        SetCorrection(m_angleToApply);
    }

}

