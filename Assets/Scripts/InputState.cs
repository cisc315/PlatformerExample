/*
 * InputManager is able to take inputs from Unity and convert them 
 * into buttons that our game can use this class will store whether 
 * the button has been pressed or released. 
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonState{
	public bool value;  // stores whether or not button has been pressed
	public float holdTime = 0;  // how long a button has actually been pressed
}

public class InputState : MonoBehaviour {

	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons,ButtonState>();

	public void SetButtonValue(Buttons key, bool value){

		if (!buttonStates.ContainsKey (key))
			buttonStates.Add (key, new ButtonState ());

		var state = buttonStates [key];
		// We can check whether a button has been released or if a button is still down, 
		// by testing the state value vs the value that's coming in when we set the button value. 
		if (state.value && !value) {
			state.holdTime = 0;
		} else if (state.value && value) {
			// deltaTime represents the number of milliseconds from one frame to another. 
			// If the time is set to zero, let's say the game is paused, this value is going 
			// to be zero. If the game is running, correctly, at it's full frame rate, it'll 
			// be a varying number of milliseconds.
			state.holdTime += Time.deltaTime;
		}
			
			
		state.value = value;
	}

	public bool GetButtonValue(Buttons key){
		if (buttonStates.ContainsKey (key))
			return buttonStates [key].value;
		else
			return false;

	}
}
