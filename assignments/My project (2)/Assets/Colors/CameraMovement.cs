using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    private float _mouseSensitivity = 3.0f;

    private float _rotationY;
    [SerializeField]
    private float _rotationX = 20f;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 5f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private Vector3 heightOffset = new Vector3(0,2.5f,0);

    [SerializeField]
    private float _smoothTime = 0f;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        //_rotationX += mouseY;

        // Apply clamping for x rotation
        
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        
        // Substract forward vector of the GameObject to point its forward vector to the target
        transform.position = _target.position - transform.forward * _distanceFromTarget + heightOffset;
    }
}
