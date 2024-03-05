using UnityEngine;
using UnityEngine.InputSystem;

namespace Weeek6 {

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] InputAction moveAction;
        [SerializeField] InputAction jumpAction;
        PlayerControllerMappings mappings;
        Rigidbody rb;
        const float SPEED = 5.5f;
        [SerializeField] float jumpForce = 5f;

        private void Awake()
        {
            mappings = new PlayerControllerMappings();
            moveAction = mappings.Player.Move;
            jumpAction = mappings.Player.Jump;
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            moveAction.Enable();
            jumpAction.Enable();
            jumpAction.performed += OnJump; //when jumping call methos w/out constantly checking every frame
        }

        private void OnDisable()
        {
            moveAction.Disable();
            jumpAction.Disable();
            jumpAction.performed -= OnJump;
        }

        private void Update()
        {
            //returns a vector2 with values of the format x,y
            //x represents input from a & d
            //y represents input from w & s
            //on a range from -1 to 1
            Vector2 input = moveAction.ReadValue<Vector2>();
            input *= SPEED; //(* Time.deltaTime) from every frame to every second

            //transform.position = new Vector3(transform.position.x + input.x, 0, transform.position.z + input.y);

            rb.velocity = new Vector3(input.x, rb.velocity.y, input.y);
        }


        bool IsGrounded()
        {
            // bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 3;
            RaycastHit hit;

            //does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                return false;
            }
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            if (IsGrounded() == false) return;
            rb.AddForce(Vector3.up * jumpForce);
        }

    }

}
