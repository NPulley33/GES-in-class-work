using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Week6 {

    public class PlayerController3D : MonoBehaviour
    {
        public Rigidbody rb;
        public PlayerControllerMappings PlayerControls;

        private InputAction move;
        private InputAction look;
        private InputAction jump;

        [SerializeField] float moveSpeed = 5.5f;
        [SerializeField] float jumpForce = 10f;
        [SerializeField] float rotation = 5.0f;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;
        private bool grounded;

        //assigns variables
        private void Awake()
        {
            PlayerControls = new PlayerControllerMappings();
            move = PlayerControls.Player.Move;
            look = PlayerControls.Player.Look;
            jump = PlayerControls.Player.Jump;
        }
        //enables input action sub actions
        private void OnEnable()
        {
            move.Enable();
            look.Enable();
            jump.Enable();
        }
        //disable sub actions
        private void OnDisable()
        {
            move.Disable();
            look.Disable();
            jump.Disable();
        }


        void Update()
        {
            //handles movement
            Vector2 input = move.ReadValue<Vector2>();
            input *= moveSpeed;
            rb.velocity = new Vector3(input.x, rb.velocity.y, input.y);

            //find a way to handle rotation via mouse movement? 
        }
    }

}