using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{

    float maxRotationAngle = 90f;



    // Update is called once per frame
    void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(90, -90 ,0);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float currentRotation = transform.rotation.eulerAngles.z;

        // Normalize the rotation to be within the range -180 to 180 degrees
        currentRotation = NormalizeAngle(currentRotation);

        // Apply the rotation limit
        currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, maxRotationAngle);


    }
    private float NormalizeAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
        {
            angle -= 360;
        }
        if (angle < -180)
        {
            angle += 360;
        }
        return angle;
    }
}
