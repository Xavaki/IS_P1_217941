using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    void Update()
    {
        // multiplying by deltaTime makes the action frame rate independent
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
