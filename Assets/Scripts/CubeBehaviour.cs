using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
         myRenderer = gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1,0);
        Debug.Log(transform.rotation);
        //Debug.Log(myRenderer.material.color);
    }
}
