using UnityEngine;
using System.Collections;

public class Duck : AbstractBehavior {

	public float scale = .5f;
	public bool ducking;
	public float centerOffsetY = 0f;

	private CircleCollider2D circleCollider;
	private Vector2 originalCenter;

	protected override void Awake ()
	{
		base.Awake ();

		circleCollider = GetComponent<CircleCollider2D> ();
		originalCenter = circleCollider.offset;
	}

	protected virtual void OnDuck(bool value) {

		ducking = value;

		//when ducking, disable walk and longjump scripts
		//pass !ducking (if ducking is true, set scripts enable to !true)
		ToggleScripts (!ducking);

		var size = circleCollider.radius;

		float newOffsetY;
		float sizeRecirpocal;

		if (ducking) {
			sizeRecirpocal = scale;
			newOffsetY = circleCollider.offset.y - size / 2 + centerOffsetY;
		} else {
			sizeRecirpocal = 1 / scale;
			newOffsetY = originalCenter.y;
		}

		size = size * sizeRecirpocal;
		circleCollider.radius = size;
		circleCollider.offset = new Vector2 (circleCollider.offset.x, newOffsetY);

	}


	// Update is called once per frame
	void Update () {

		var canDuck = inputState.GetButtonValue (inputButtons [0]);
		if (canDuck && collisionState.standing && !ducking) {
			OnDuck (true);
		} else if (ducking && !canDuck) {
			OnDuck (false);
		}
	
	}
}
