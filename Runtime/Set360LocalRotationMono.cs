using UnityEngine;

public class Set360LocalRotationMono : MonoBehaviour
{
    public Transform m_affected;
    public Item360Angle m_rotation;

    public void Refresh()
    {
        m_rotation.GetAsRotation(out Quaternion localRotation);
        m_affected.localRotation = localRotation;
    }
    public void SetRotation(Item360Angle rotation)
    {
        m_rotation = rotation;
        Refresh();
    }

    public void Set(float horizontalLR, float verticalDT, float tiltlR)
    {
        m_rotation.m_horizontalLeftRight = horizontalLR;
        m_rotation.m_verticalDownTop = verticalDT;
        m_rotation.m_tiltLeftRight = tiltlR;
        Refresh();
    }

    private void OnValidate()
    {
        SetRotation(m_rotation);
    }
}
