using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public Transform target;
    public float mousesensitive = 5f;
    public float verticalrota;
    public float horizontalrota;

    public void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        transform.position = target.position;

        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        verticalrota -= MouseY * mousesensitive;
        verticalrota = Mathf.Clamp(verticalrota, -80f, 80f);

        horizontalrota += MouseX * mousesensitive;

        transform.rotation = Quaternion.Euler(verticalrota,horizontalrota, 0);

    }
}
