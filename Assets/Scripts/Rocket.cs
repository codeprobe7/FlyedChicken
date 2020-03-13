using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private void Update()
    {
        Vector3 direction = Rstick.direction;
        transform.LookAt(transform.position + direction);
    }
}
