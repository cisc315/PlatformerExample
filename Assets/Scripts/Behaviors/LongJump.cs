using UnityEngine;
using System.Collections;

public class LongJump : Jump {

	public float longJumpDelay = .15f;
	public float longJumpMultiplier = 1.5f;
	public bool canLongJump;
	public bool isLongJumping;

	protected override void Update() {

		var canJump = inputState.GetButtonValue (inputButtons [0]);
		var holdTime = inputState.GetButtonHoldTime(inputButtons [0]);

		if (!canJump)
			canLongJump = false;

		// if just finished long jump, reset to false
		if (collisionState.standing && isLongJumping)
			isLongJumping = false;

		// call Jump Update function
		base.Update();

		// jump and double jump and see if player holding down key for long jump
		if (canLongJump && !collisionState.standing && holdTime > longJumpDelay) {
			var vel = body2d.velocity;
			body2d.velocity = new Vector2 (vel.x, jumpSpeed * longJumpMultiplier);
			canLongJump = false;
			isLongJumping = true;
		}

	}

	protected override void OnJump ()
	{
		base.OnJump ();
		canLongJump = true;
	}
}
