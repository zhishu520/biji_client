using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUtility : Singleton<TouchUtility> {

	bool isTouchBegan(){
		if (Input.GetMouseButtonDown (0))
			return true;
		if (Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Began)
			return true;
		return false;
	}

	bool isTouchEnded(){
		if (Input.GetMouseButtonUp (0))
			return true;
		if (Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Ended)
			return true;
		return false;
	}

	bool isTouchMoved(){
		if (Input.GetMouseButtonDown (0))
			return true;
		if (Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Moved)
			return true;
		return false;
	}


	Vector3 getTouchPoint() {
		if (Input.GetMouseButtonDown (0))
			return Input.mousePosition;
		if (Input.touchCount > 0)
			return Input.GetTouch (0).position;
		return new Vector3(0,0,0);
	}


}
