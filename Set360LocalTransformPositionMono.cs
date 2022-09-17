using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set360LocalTransformPositionMono : MonoBehaviour
{
    public Transform m_root;
    public Transform m_toRotate;
    public Item360Angle m_localAnglePosition;

    public float m_positionDepth=10;


    

    public void RefreshPosition() {

        if (m_root != null && m_toRotate!=null) {

            Quaternion localRotation = Quaternion.Euler(
            m_localAnglePosition.m_vertical,
            m_localAnglePosition.m_horizontal,
            -m_localAnglePosition.m_tilt);
            Vector3 localPosition = localRotation * (Vector3.forward * m_positionDepth);
            Eloi.E_RelocationUtility.GetLocalToWorld_DirectionalPoint(localPosition, localRotation, in m_root, out Vector3 wp, out Quaternion wr);
            m_toRotate.position = wp;
            m_toRotate.rotation = wr;

        }
    }
    private void OnValidate()
    {
        RefreshPosition();
    }
}
