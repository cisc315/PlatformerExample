using UnityEngine;
using System.Collections;

public class Equip : AbstractBehavior {

	private int _currentItem = 0;
	private Animator animator;

	public int currentItem{
		get { return _currentItem; }
		set {
			_currentItem = value; //value is automatically passed to this getter/setter
			animator.SetInteger("EquippedItem", _currentItem );
		}

	}

	override protected void Awake() {
		base.Awake ();
		animator = GetComponent<Animator> ();
	}

}