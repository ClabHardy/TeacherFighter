﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//This is the script that Mr Taylor Uses for movement

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class TaylorFightControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Dodge;

        private bool m_FacingRight = true;

        private Vector3 startPosition;
        private Animator anim;

        public SimpleHealthBar playerHealthBar;
      
     
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            startPosition = transform.position;
            anim = gameObject.GetComponent<Animator>();
            
        }


        private void Update()
        {
            playerHealthBar = gameObject.GetComponent<PlatformerCharacter2D>().healthBarObject.GetComponent<SimpleHealthBar>();

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            if (!m_Dodge)
            {
                // Read the dodge input in Update so button presses aren't missed.
                m_Dodge = CrossPlatformInputManager.GetButtonDown("Dodge");
            }
            //Canvas.healthBarLeft.UpdateBar((Canvas.healthBarLeft.GetCurrentFraction * 100) - 10, 100);
            //Debug.Log(Canvas.healthBarLeft.GetCurrentFraction * 100);
            
            if (playerHealthBar.GetCurrentFraction <= 0) {
                //Debug.Log("EE RERER");
                Destroy(gameObject);
            }
        }


        private void FixedUpdate()
        {
            if(Input.GetKey("o")){
            }

            

            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //Debug.Log(h);
            //Debug.Log(m_Character.transform.);
            if(m_Dodge) {
                if(h > 0) {
                    h = 5;
                }
                else if (h < 0) {
                    h = (-5);
                }
                //Canvas.healthBarLeft.UpdateBar((Canvas.healthBarLeft.GetCurrentFraction * 100) - 10, 100);
            }

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
            m_Dodge = false;

            
        }

        private void Flip()
        {
            m_FacingRight = !m_FacingRight;

            transform.Rotate(0f, 180f, 0f);
        }

    }
        
}
