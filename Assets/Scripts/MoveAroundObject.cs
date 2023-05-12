using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAroundObject : MonoBehaviour
{

    public float mouseSensitivity = 3.0f;

    private float rotationY;
    private float rotationX;

    public Transform target;

    public float distanceFromTarget = 6.0f;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity;

        //Debug.Log(mouseX);

        rotationY += mouseX;
        rotationX += mouseY;

        rotationX = Mathf.Clamp(rotationX, 20, 60);

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        float zoomAmount = Mouse.current.scroll.ReadValue().y * 3 * -1;

        distance += zoomAmount / 360;

        distance = Mathf.Clamp(distance, 4, 11);

        Debug.Log(distance);

        transform.position = target.position - transform.forward * distance;
        

    }



}
