using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment
{
    private float _horizontalInput;
    private float _verticalInput;
    private GameObject _movedObject;
    public bool _isVerticalKeysPressed;

    public Movment(GameObject movedObject)
    {
        _movedObject = movedObject;
    }

    public void ManageMovment()
    {
        _isVerticalKeysPressed = Mathf.Abs(_verticalInput) > Mathf.Epsilon;

        if (_isVerticalKeysPressed)
        {
            MovePlayerByAxis();
        }

    }

    private void MovePlayerByAxis()
    {
        _movedObject.transform.Translate(0, _verticalInput, 0);
        bool horizontalKeysPressed = Mathf.Abs(_horizontalInput) > Mathf.Epsilon;

        if (horizontalKeysPressed)
        {
            _movedObject.transform.Rotate(0, 0, -_horizontalInput);
        }
    }

    public void UpdatePositionsByAxis(float steerSpeed, float moveSpeed)
    {
        _horizontalInput = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        _verticalInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
    }
}
