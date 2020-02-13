﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//This is the script that Mr Taylor Uses for movement

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class VonDerEheFightControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Dodge;

        private Vector3 startPosition;

        private SimpleHealthBar playerHealthBar;
        private SimpleHealthBar staminaBar;

        
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            startPosition = transform.position;
            playerHealthBar = gameObject.GetComponent<PlatformerCharacter2D>().healthBarObject.GetComponent<SimpleHealthBar>();
            staminaBar = gameObject.GetComponent<PlatformerCharacter2D>().staminaBarObject.GetComponent<SimpleHealthBar>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump2");
            }
            // if (!m_Dodge)
            // {
            //     // Read the dodge input in Update so button presses aren't missed.
            //     m_Dodge = CrossPlatformInputManager.GetButtonDown("Dodge");
            // }
            
        }


        private void FixedUpdate()
        {
            if(Input.GetKey("o")){
                transform.position = startPosition;
            }
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.RightControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal2");
            //Debug.Log(h);
            //Debug.Log(m_Character.transform.);
            if(m_Dodge) {
                if(h > 0) {
                    h = 5;
                }
                else if (h < 0) {
                    h = (-5);
                }
            }
            //Debug.Log(crouch);
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
            m_Dodge = false;
            
        }
    }
        
}
