using UnityEngine;

public class TouchInput : MonoBehaviour {
    Vector2 startPos;
    float startTime;
    [Range(0.1f, 1f)] public float maxSwipeTime = 0.5f;
    [Range(0.1f, 1f)] public float minSwipeDist = 0.17f;

    private void Update() {
        //begin check if input detects a touch
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);
            //get starting position and time of touch start
			if (t.phase == TouchPhase.Began) {
				startPos = new Vector2(t.position.x/(float)Screen.width, t.position.y/(float)Screen.width);
				startTime = Time.time;
			}
            //determine touch intention and execute accordingly when touch ends
			if (t.phase == TouchPhase.Ended) {
				if (Time.time - startTime > maxSwipeTime)
					return; //pressed too long to be a swipe, treat as long press / hold

				Vector2 endPos = new Vector2(t.position.x/(float)Screen.width, t.position.y/(float)Screen.width);
				Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
				//if (swipe.magnitude < _minSwipeDist)
				//	return; //distance too short to be a swipe, treat as tap

				if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y)) { //horizontal swipe
					if (swipe.x > 0) {
						return; //swiped right
					} else {
						return; //swiped left
					}
				} else { //vertical swipe
					if (swipe.y > 0) {
						return; //swiped up
					} else {
						return; //swiped down
					}
				}
			}
		}
    }
}