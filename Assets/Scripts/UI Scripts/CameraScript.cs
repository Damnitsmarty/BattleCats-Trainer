using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public MobileInputScript MobileInput;
	public MobileInputScript MobileInputs;

	public float FOVZoomOut = 60;                     // The field of view for the camera
	public float FOVZoomIn = 12;
	public float dragMultiplier = 0.1f;                           // The speed the player can move the camera at
    public float zoomMultiplier = 0.1f;


	public float CameraLocked = 0;                          // If the camera is Locked it cannot move, Movement speed is set to 0
	public float CameraUnlocked = 1f;                       // If the camera is unlocked it can now move

	private float lastPinchDistance = -1;

	void Log(string text)
	{
		GameObject.Find("Logger").GetComponent<UnityEngine.UI.Text>().text += "\n" + text;
	}
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
       


			// -1, if the user is not actually pinching
			float currentPinchDistance = getPinchDistance();

			// When the user starts pinching, the lastPinchDistance
			// is updated from -1 to the current distance

			// Hence if the value is bigger than -1
			// we can get an accurate delta of the distances
//			if (Input.touchCount > 1 && lastPinchDistance > -1)
//			{
//				Camera camera = GetComponent<Camera>();
//				float delta = lastPinchDistance - currentPinchDistance;
//				camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + delta * zoomMultiplier, FOVZoomIn, FOVZoomOut);


				//Clamp, so it doesn't exceed the limits of the zoom
				//pos.z = Mathf.Clamp(pos.z, -MinZoom, MaxZoom);
				//Update the transform of the camera
			
			if(Input.touchCount == 1)                       // If the player touches the screen with 2 fingers
			{
                //Cast a ray, to see if it hits any draggable objects;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);            // A ray cast is sent from the point on the screen they touched
                RaycastHit hit;                
                if (Physics.Raycast(ray, out hit))             
                {
                    if (hit.collider.GetComponent<RoomCheckerScript>()) return;                
                }

				if (MobileInputs.CatPickedUp == true)                       // If the player is picking up a cat they cannot move the camera
				{
				dragMultiplier = 0f;
					Debug.Log ("Cat Picked Up");

				}
			if (MobileInput.CatPickedUp == false)                          // When they drop the cat they can move again
			{
				dragMultiplier = 0.01f/2;
				Debug.Log ("Cat Dropped");
			}
				//Moving
				Vector2 dPos = Input.GetTouch(0).deltaPosition;                    // Changes the position of the camera Based on the players finger movemnts
				//slow the movement
				dPos *= dragMultiplier;

            if (dPos.y >= 0.5)
            {
                transform.position += new Vector3(0, -dPos.y, 0);                  // Updates the Camaras position, The Camera can only move up and down 
            }
			}
			// Always update the last pinch distance (even when -1)
			lastPinchDistance = currentPinchDistance;
		}
	float getPinchDistance()
	{
		if (Input.touchCount < 2) return -1;
		Touch touch0 = Input.GetTouch(0);
		Touch touch1 = Input.GetTouch(1);

		return Vector2.Distance(touch0.position, touch1.position);
	}
}


