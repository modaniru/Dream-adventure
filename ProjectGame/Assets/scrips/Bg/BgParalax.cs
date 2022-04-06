using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgParalax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float parallaxSrength = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPosition;

    private void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }
        targetPreviousPosition = followingTarget.position;
    }
    private void Update()
    {
        Vector3 delta = followingTarget.position - targetPreviousPosition;
        if (disableVerticalParallax)
        {
            delta.y = 0;
        }
        targetPreviousPosition = followingTarget.position;
        transform.position += delta * parallaxSrength;
    }
}
