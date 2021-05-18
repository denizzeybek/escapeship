using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

        CharacterController controller;
        Vector3 velocity;
        AudioSource source;

        bool isGrounded;

        public Transform ground;
        public float distance = 0.3f;
        public bool isMoving; 
        public float speed;
        public float jumpHeight;
        public float gravity;

        public float originalHeight;
        public float crouchHeight;

        public LayerMask mask;

        public AudioClip[] stepSounds;


        public float timeBetweenSteps;
        float timer;




        // Start is called before the first frame update
        void Start ()
        {
                controller = GetComponent<CharacterController> ();
                source = GetComponent<AudioSource> ();
        }

        // Update is called once per frame
        void Update()
        {
                #region Movement

                float horizontal = Input.GetAxis ("Horizontal");
                float vertical = Input.GetAxis ("Vertical");

                Vector3 move = transform.right * horizontal + transform.forward * vertical;
                controller.Move (move * speed * Time.deltaTime);

                #endregion

                #region Footsteps

                if (horizontal != 0 || vertical != 0)
                        isMoving = true;
                else
                        isMoving = false;

		if (isMoving)
		{
                        timer -= Time.deltaTime;

                        if(timer <= 0)
			{
                                timer = timeBetweenSteps;
                                source.clip = stepSounds [Random.Range (0, stepSounds.Length)];
                                source.pitch = Random.Range (0.85f, 1.15f);
                                source.Play ();
			}
		}
		else
		{
                        timer = timeBetweenSteps;
		}


		#endregion


		#region Jump

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                        velocity.y += Mathf.Sqrt (jumpHeight * -3.0f * gravity);
		}


                #endregion
                 
                #region Gravity

                isGrounded = Physics.CheckSphere (ground.position, distance, mask);

                if(isGrounded && velocity.y < 0)
                {
                        velocity.y = 0f;
		}

                velocity.y += gravity * Time.deltaTime;
                controller.Move (velocity * Time.deltaTime);


		#endregion

                # region Basic Crouch

                if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown (KeyCode.LeftCommand))
		{
                        controller.height = crouchHeight;
                        speed = 2.0f;
                        jumpHeight = 0;
		}

                if (Input.GetKeyUp (KeyCode.LeftControl) || Input.GetKeyDown (KeyCode.LeftCommand))
                {
                        jumpHeight = 1;
                        speed = 50.0f;
                        controller.height = originalHeight;
                }
		#endregion

		#region Basic Running

		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
                        speed = 70.0f;
                        timeBetweenSteps = 0.3f;
		}
                if (Input.GetKeyUp (KeyCode.LeftShift))
                {
                        speed = 50.0f;
                        timeBetweenSteps = 0.5f;

                }

                #endregion
        }
}
