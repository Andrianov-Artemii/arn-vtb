using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class MapPointerController : MonoBehaviour
{
    public RectTransform map;

    public RectTransform me, target;
    public UnityEngine.UI.Extensions.UILineRenderer lineRenderer;

    public Vector2 mapScale;

    [Space]
    public Transform testPoint;
    public RectTransform testPointImage;

    private void Start()
    {
        target.gameObject.SetActive(false);
        me.gameObject.SetActive(false);
        PositionUnit.PositionInterface.onARCameraTramsformUpdate += OnTransformUpdate;
        NavUnit.NavInterface.onPathFound += OnPathFound;
        DeviceChange.OnOrientationChange += OnOrientationChange;
    }

    private void OnOrientationChange(DeviceOrientation obj)
    {
        if (oldTargetPos != Vector3.zero)
        {
            SetTargetPos(oldTargetPos);
        }

        if (oldTransformUpdatePos != Vector3.zero)
        {
            OnTransformUpdate(oldTransformUpdatePos, oldTransformUpdateRot);
        }

        if (oldPathFound != null)
        {
            OnPathFound(oldPathFound);
        }
    }

    Vector3[] oldPathFound = null;
    private void OnPathFound(Vector3[] points)
    {
        oldPathFound = points;
        List<Vector2> p = points.ToList().ConvertAll(t => GetReleativePos(t));
        if (p.Count > 0 && PositionUnit.PositionInterface.posStatus == PositionUnit.PosStatus.normal)
        {
            p[0] = me.anchoredPosition;
        }
        lineRenderer.Points = p.ToArray();
    }

    Vector2 GetReleativePos(Vector3 pos)
    {
        float x = map.rect.width * pos.x / mapScale.x;
        float y = map.rect.height * pos.z / mapScale.y;
        return new Vector2(x, y);
    }

    bool firstTargetSet = false;
    Vector3 oldTargetPos = Vector3.zero;
    public void SetTargetPos(Vector3 pos)
    {
        oldTargetPos = pos;
        if (!firstTargetSet)
        {
            target.gameObject.SetActive(true);
            firstTargetSet = true;
        }
        target.anchoredPosition = GetReleativePos(pos);
    }

    bool firstTransformUpdate = false;
    Vector3 oldTransformUpdatePos = Vector3.zero;
    Quaternion oldTransformUpdateRot;
    void OnTransformUpdate(Vector3 position, Quaternion rotation)
    {
        oldTransformUpdatePos = position;
        oldTransformUpdateRot = rotation;
        if (!firstTransformUpdate && PositionUnit.PositionInterface.posStatus == PositionUnit.PosStatus.normal)
        {
            me.gameObject.SetActive(true);
            firstTransformUpdate = true;
        }

        if (lineRenderer.Points.Length > 0 && PositionUnit.PositionInterface.posStatus == PositionUnit.PosStatus.normal)
        {
            lineRenderer.Points[0] = me.anchoredPosition;
            lineRenderer.SetAllDirty();
        }

        me.anchoredPosition = GetReleativePos(position);
        me.rotation = Quaternion.Euler(0, 0, -GetUIRotation(rotation));
    }

    public float GetUIRotation(Quaternion rotation)
    {
        Vector3 forward = rotation * Vector3.forward;
        Vector3 up = rotation * Vector3.up;

        Vector2 proj1 = new Vector2(forward.x, forward.z);
        Vector2 proj2 = new Vector2(up.x, up.z);

        if (proj1.magnitude >.7f)
        {
            return -AngleBetvinVectors(new Vector2(0, 1), proj1);

        }
        else if (proj1.magnitude >.5f)
        {
            float a1 = -AngleBetvinVectors(new Vector2(0, 1), proj1);
            float a2 = -AngleBetvinVectors(new Vector2(0, 1), proj2);
            float t = (.7f - proj1.magnitude) * 5f;

            return Mathf.LerpAngle(a1, a2, t);
        }
        else
        {
            return -AngleBetvinVectors(new Vector2(0, 1), proj2);
        }
    }

    float AngleBetvinVectors(Vector2 a, Vector2 b)
    {
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(Vector3.forward, Vector3.Cross(a, b)));
        float signed_angle = angle * sign;
        float angle360 = (signed_angle) % 360;
        return angle360;
    }


#if UNITY_EDITOR
    private void Update()
    {
        if (testPointImage && testPoint)
            testPointImage.anchoredPosition = GetReleativePos(testPoint.position);
    }
#endif

}
