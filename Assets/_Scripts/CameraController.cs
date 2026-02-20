using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    /*
        public Transform player;

        public float offSetX; // resembles looking over shoulder of player (if looking at back of the player)
        public float offSetY; // camera height
        public float offSetZ; // distance to player - the closer to 0 the value gets, the closer to the player
        private float playerFaceingDownOffset = 3f;
        */

    public Rigidbody _rigidbody;
    public float _moveSpeed;

    public InputActionReference move;


    private Vector2 _moveDirection;


    private Vector3 cameraOffset;



    // LERP
    private float elapsedTime;
    private float desiredDuration = 1f;

   // [SerializeField]
   // public AnimationCurve curve;




    void Start()
    {
        if(_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }

    /// <summary>
    /// Rotates the camera by 30 degrees Left or Right depending on input. Default Keys to rotate:
    /// Q: Left
    /// E: Right
    /// </summary>
    public void TurnCameraIncremental()
    {

    }

    /// <summary>
    /// Move the camera depending on Input.
    /// Default Movement: WASD 
    /// </summary>
    public void MoveCamera()
    {

    }

}
