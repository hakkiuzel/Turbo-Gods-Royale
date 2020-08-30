using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace TLGFPowerJoysticks {

	public class PowerJoystickInputManager : MonoBehaviour {

		private PowerJoystick powerJoystick;
		private PowerDPad powerDPad;
		private PowerButton powerButton;
		private enum PowerType {Joystick, DPad, Button};
		private PowerType powerType;
		private CrossPlatformInputManager.VirtualAxis horizontalAxis;
		private CrossPlatformInputManager.VirtualAxis verticalAxis;
		private string buttonAxisName;
		private CrossPlatformInputManager.VirtualAxis buttonAxis;
		private CrossPlatformInputManager.VirtualButton button;


		void OnEnable () {
			// Get power component
			powerJoystick = GetComponent<PowerJoystick> ();
			powerDPad = GetComponent<PowerDPad> ();
			powerButton = GetComponent<PowerButton> ();
			if(powerJoystick != null) {
				powerType = PowerType.Joystick;
			} else if(powerDPad != null) {
				powerType = PowerType.DPad;
			} else if(powerButton != null) {
				powerType = PowerType.Button;
			}

			// Subscribe to trigger events
			if (powerType == PowerType.Joystick) {
				PowerJoystick.OnJoyPosHTriggerButtonDown += PosHTriggerButtonDown;
				PowerJoystick.OnJoyPosHTriggerButtonUp += PosHTriggerButtonUp;
				PowerJoystick.OnJoyNegHTriggerButtonDown += NegHTriggerButtonDown;
				PowerJoystick.OnJoyNegHTriggerButtonUp += NegHTriggerButtonUp;
				PowerJoystick.OnJoyPosVTriggerButtonDown += PosVTriggerButtonDown;
				PowerJoystick.OnJoyPosVTriggerButtonUp += PosVTriggerButtonUp;
				PowerJoystick.OnJoyNegVTriggerButtonDown += NegVTriggerButtonDown;
				PowerJoystick.OnJoyNegVTriggerButtonUp += NegVTriggerButtonUp;
			}
			if (powerType == PowerType.DPad) {
				PowerDPad.OnDPadPosHTriggerButtonDown += PosHTriggerButtonDown;
				PowerDPad.OnDPadPosHTriggerButtonUp += PosHTriggerButtonUp;
				PowerDPad.OnDPadNegHTriggerButtonDown += NegHTriggerButtonDown;
				PowerDPad.OnDPadNegHTriggerButtonUp += NegHTriggerButtonUp;
				PowerDPad.OnDPadPosVTriggerButtonDown += PosVTriggerButtonDown;
				PowerDPad.OnDPadPosVTriggerButtonUp += PosVTriggerButtonUp;
				PowerDPad.OnDPadNegVTriggerButtonDown += NegVTriggerButtonDown;
				PowerDPad.OnDPadNegVTriggerButtonUp += NegVTriggerButtonUp;
			}
			// Subscribe to normal button events
			if (powerType == PowerType.Button) {
				PowerButton.OnPowerButtonDown += OnPowerButtonDown;
				PowerButton.OnPowerButtonUp += OnPowerButtonUp;
			}

			// Register joystick axis
			if (powerType == PowerType.Joystick) {
				if(powerJoystick.useAxis == PowerJoystick.UseAxis.Both || powerJoystick.useAxis == PowerJoystick.UseAxis.Horizontal) {
					if(powerJoystick.GetHorizontalAxisName() != "" && !CrossPlatformInputManager.AxisExists(powerJoystick.GetHorizontalAxisName())) {
						horizontalAxis = new CrossPlatformInputManager.VirtualAxis (powerJoystick.GetHorizontalAxisName());
						CrossPlatformInputManager.RegisterVirtualAxis (horizontalAxis);
					}
					// Unregister doesn't work correctly / Get axis reference (necessary if joysticks gets disbled and enabled again)
					if (powerJoystick.GetHorizontalAxisName () != "" && CrossPlatformInputManager.AxisExists (powerJoystick.GetHorizontalAxisName ())) {
						horizontalAxis= CrossPlatformInputManager.VirtualAxisReference (powerJoystick.GetHorizontalAxisName());
					}
				}
				if(powerJoystick.useAxis == PowerJoystick.UseAxis.Both || powerJoystick.useAxis == PowerJoystick.UseAxis.Vertical) {
					if(powerJoystick.GetVerticalAxisName() != "" && !CrossPlatformInputManager.AxisExists(powerJoystick.GetVerticalAxisName())) {
						verticalAxis = new CrossPlatformInputManager.VirtualAxis (powerJoystick.GetVerticalAxisName());
						CrossPlatformInputManager.RegisterVirtualAxis (verticalAxis);
					}
					// Unregister doesn't work correctly / Get axis reference (necessary if joysticks gets disbled and enabled again)
					if (powerJoystick.GetVerticalAxisName () != "" && CrossPlatformInputManager.AxisExists (powerJoystick.GetVerticalAxisName ())) {
						verticalAxis = CrossPlatformInputManager.VirtualAxisReference (powerJoystick.GetVerticalAxisName());
					}
				}
			}

			// Register d-pad axis
			if (powerType == PowerType.DPad) {
				if(powerDPad.useAxis == PowerDPad.UseAxis.Both || powerDPad.useAxis == PowerDPad.UseAxis.Horizontal) {
					if(powerDPad.GetHorizontalAxisName() != "" && !CrossPlatformInputManager.AxisExists(powerDPad.GetHorizontalAxisName())) {
						horizontalAxis = new CrossPlatformInputManager.VirtualAxis (powerDPad.GetHorizontalAxisName());
						CrossPlatformInputManager.RegisterVirtualAxis (horizontalAxis);
					}
					// Unregister doesn't work correctly / Get axis reference (necessary if d-pad gets disbled and enabled again)
					if (powerDPad.GetHorizontalAxisName () != "" && CrossPlatformInputManager.AxisExists (powerDPad.GetHorizontalAxisName ())) {
						horizontalAxis = CrossPlatformInputManager.VirtualAxisReference (powerDPad.GetHorizontalAxisName());
					}

				}
				if(powerDPad.useAxis == PowerDPad.UseAxis.Both || powerDPad.useAxis == PowerDPad.UseAxis.Vertical) {
					if(powerDPad.GetVerticalAxisName() != "" && !CrossPlatformInputManager.AxisExists(powerDPad.GetVerticalAxisName())) {
						verticalAxis = new CrossPlatformInputManager.VirtualAxis (powerDPad.GetVerticalAxisName());
						CrossPlatformInputManager.RegisterVirtualAxis (verticalAxis);
					}
					// Unregister doesn't work correctly / Get axis reference (necessary if d-pad gets disbled and enabled again)
					if (powerDPad.GetVerticalAxisName () != "" && CrossPlatformInputManager.AxisExists (powerDPad.GetVerticalAxisName ())) {
						verticalAxis = CrossPlatformInputManager.VirtualAxisReference (powerDPad.GetVerticalAxisName());
					}
				}
			}

			// Register button 
			if(powerType == PowerType.Button) {
				if(powerButton.GetButtonName() != null) {
					if(!CrossPlatformInputManager.ButtonExists(powerButton.GetButtonName())) {
						button = new CrossPlatformInputManager.VirtualButton (powerButton.GetButtonName());
						CrossPlatformInputManager.RegisterVirtualButton (button);
					}
				}
			}

			// Register button axis
			if(powerType == PowerType.Button) {
				if(powerButton.GetButtonToAxis() && powerButton.GetAxisName() != "") {
					buttonAxisName = powerButton.GetAxisName ();
					if(!CrossPlatformInputManager.AxisExists(buttonAxisName)) {
						buttonAxis = new CrossPlatformInputManager.VirtualAxis (buttonAxisName);
						CrossPlatformInputManager.RegisterVirtualAxis (buttonAxis);
					}
					// Unregister doesn't work correctly / Get axis reference (necessary if button gets disbled and enabled again)
					if (powerButton.GetAxisName () != "" && CrossPlatformInputManager.AxisExists (powerButton.GetAxisName ())) {
						buttonAxis = CrossPlatformInputManager.VirtualAxisReference (powerButton.GetAxisName());
					}
				}
			}
		}

		void OnDisable () {
			// Unsubscribe trigger events
			if (powerType == PowerType.Joystick) {
				PowerJoystick.OnJoyPosHTriggerButtonDown -= PosHTriggerButtonDown;
				PowerJoystick.OnJoyPosHTriggerButtonUp -= PosHTriggerButtonUp;
				PowerJoystick.OnJoyNegHTriggerButtonDown -= NegHTriggerButtonDown;
				PowerJoystick.OnJoyNegHTriggerButtonUp -= NegHTriggerButtonUp;
				PowerJoystick.OnJoyPosVTriggerButtonDown -= PosVTriggerButtonDown;
				PowerJoystick.OnJoyPosVTriggerButtonUp -= PosVTriggerButtonUp;
				PowerJoystick.OnJoyNegVTriggerButtonDown -= NegVTriggerButtonDown;
				PowerJoystick.OnJoyNegVTriggerButtonUp -= NegVTriggerButtonUp;
			}
			if (powerType == PowerType.DPad) {
				PowerDPad.OnDPadPosHTriggerButtonDown -= PosHTriggerButtonDown;
				PowerDPad.OnDPadPosHTriggerButtonUp -= PosHTriggerButtonUp;
				PowerDPad.OnDPadNegHTriggerButtonDown -= NegHTriggerButtonDown;
				PowerDPad.OnDPadNegHTriggerButtonUp -= NegHTriggerButtonUp;
				PowerDPad.OnDPadPosVTriggerButtonDown -= PosVTriggerButtonDown;
				PowerDPad.OnDPadPosVTriggerButtonUp -= PosVTriggerButtonUp;
				PowerDPad.OnDPadNegVTriggerButtonDown -= NegVTriggerButtonDown;
				PowerDPad.OnDPadNegVTriggerButtonUp -= NegVTriggerButtonUp;
			}
			// Unsubscribe normal button events
			if (powerType == PowerType.Button) {
				PowerButton.OnPowerButtonDown -= OnPowerButtonDown;
				PowerButton.OnPowerButtonUp -= OnPowerButtonUp;
			}
				
			// Unregister axis and button
			if(horizontalAxis != null && CrossPlatformInputManager.AxisExists(horizontalAxis.name)) {
				CrossPlatformInputManager.UnRegisterVirtualAxis (horizontalAxis.name);
			}
			if(verticalAxis != null && CrossPlatformInputManager.AxisExists(verticalAxis.name)) {
				CrossPlatformInputManager.UnRegisterVirtualAxis (verticalAxis.name);
			}
			if(buttonAxis != null && CrossPlatformInputManager.AxisExists(buttonAxisName)) {
				CrossPlatformInputManager.UnRegisterVirtualAxis (buttonAxisName);
			}
			if(button != null && CrossPlatformInputManager.ButtonExists(button.name)) {
				CrossPlatformInputManager.UnRegisterVirtualButton (button.name);
			}
		}
		
		// Update is called once per frame
		void Update () {
			// Update joystick axis
			if (powerType == PowerType.Joystick) {
				if(horizontalAxis != null) {
					horizontalAxis.Update (powerJoystick.GetHorizontalAxisValue());
				}
				if(verticalAxis != null) {
					verticalAxis.Update (powerJoystick.GetVerticalAxisValue());
				}
			}

			// Update d-pad axis 
			if (powerType == PowerType.DPad) {
				if(horizontalAxis != null) {
					horizontalAxis.Update (powerDPad.GetHorizontalAxisValue());
				}
				if(verticalAxis != null) {
					verticalAxis.Update (powerDPad.GetVerticalAxisValue());
				}
			}

			// Update button axis
			if (powerType == PowerType.Button) {
				if (buttonAxisName != null && CrossPlatformInputManager.AxisExists(buttonAxisName)) {
					if (powerButton.GetButtonState () == PowerButton.ButtonState.PRESSED) {
						buttonAxis.Update (powerButton.GetAxisValue());
					}
					if (powerButton.GetButtonState () == PowerButton.ButtonState.RELEASED && !powerButton.IsNegativeAxis() && buttonAxis.GetValue > 0) {
						buttonAxis.Update (0);
					}
					if (powerButton.GetButtonState () == PowerButton.ButtonState.RELEASED && powerButton.IsNegativeAxis() && buttonAxis.GetValue < 0) {
						buttonAxis.Update (0);
					}
				}
			}
		}
			
		// Axis to button trigger
		void PosHTriggerButtonDown (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetHPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerJoystick.GetHPosButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetHPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerDPad.GetHPosButtonName ());
					#endif
				}
			}
		}
		void NegHTriggerButtonDown (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetHNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerJoystick.GetHNegButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetHNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerDPad.GetHNegButtonName ());
					#endif
				}
			}
		}
		void PosVTriggerButtonDown (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetVPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerJoystick.GetVPosButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetVPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerDPad.GetVPosButtonName ());
					#endif
				}
			}
		}
		void NegVTriggerButtonDown (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetVNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerJoystick.GetVNegButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetVNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonDown (powerDPad.GetVNegButtonName ());
					#endif
				}
			}
		}

		void PosHTriggerButtonUp (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetHPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerJoystick.GetHPosButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetHPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerDPad.GetHPosButtonName ());
					#endif
				}

			}
		}
		void NegHTriggerButtonUp (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetHNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerJoystick.GetHNegButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetHNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerDPad.GetHNegButtonName ());
					#endif
				}

			}
		}
		void PosVTriggerButtonUp (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetVPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerJoystick.GetVPosButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetVPosButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerDPad.GetVPosButtonName ());
					#endif
				}

			}
		}
		void NegVTriggerButtonUp (GameObject sender) {
			if (powerType == PowerType.Joystick) {
				if (sender == powerJoystick.gameObject && CrossPlatformInputManager.ButtonExists (powerJoystick.GetVNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerJoystick.GetVNegButtonName ());
					#endif
				}
			}

			if (powerType == PowerType.DPad) {
				if (sender == powerDPad.gameObject && CrossPlatformInputManager.ButtonExists (powerDPad.GetVNegButtonName ())) {
					#if MOBILE_INPUT
					CrossPlatformInputManager.SetButtonUp (powerDPad.GetVNegButtonName ());
					#endif
				}

			}
		}

		// Normal button events
		void OnPowerButtonDown (GameObject sender) {
			if (sender == powerButton.gameObject && CrossPlatformInputManager.ButtonExists (powerButton.GetButtonName ())) {
				#if MOBILE_INPUT
				CrossPlatformInputManager.SetButtonDown (powerButton.GetButtonName ());
				#endif
			}
		}

		void OnPowerButtonUp (GameObject sender) {
			if (sender == powerButton.gameObject && CrossPlatformInputManager.ButtonExists (powerButton.GetButtonName ())) {
				#if MOBILE_INPUT
				CrossPlatformInputManager.SetButtonUp (powerButton.GetButtonName ());
				#endif
			}
		}
	}
}
