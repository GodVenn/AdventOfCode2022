using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    public GameObject target;
    public Vector2 offset;

    private Camera Camera;

    private void Start()
    {
        Camera = FindObjectOfType(typeof(Camera)) as Camera;
    }

    void Update()
    {
        ((RectTransform)transform).anchoredPosition = Camera.WorldToScreenPoint(target.transform.position) + (Vector3)offset;
    }
}
