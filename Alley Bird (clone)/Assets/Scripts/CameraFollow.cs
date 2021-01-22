/*
*	TickLuck
*	All rights reserved
*/
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    #endregion

    #region UnityMethods
    void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        desiredPos.x = transform.position.x;
        transform.position = desiredPos;
    }
    #endregion
}
