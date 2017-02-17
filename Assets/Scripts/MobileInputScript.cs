using UnityEngine;
using System.Collections;

public class MobileInputScript : MonoBehaviour
{

	public float speed = 100;
	public GameObject Cat;
	public GameObject CatPosition;
	public bool CatPickedUp;
	public Sprite CatPickedUpSprite;
	public Sprite CatDownSprite;


	public ConstructionScript ConstructionMenu;


	SpriteRenderer SpriteRender;


	// Use this for initialization
	void Start ()
	{
		SpriteRender = GetComponent<SpriteRenderer> ();

		CatPickedUp = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		CatPickedUp = false;




		if (Input.touchCount == 1) {
			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
				

			
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
					
					// Gets the change of position of the finger since the last frame
					Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

					// Move the cat across the Screen
					transform.position = new Vector3 (touchPos.x, touchPos.y, -0.5f);


				}
			}
		}



		if (CatPickedUp == true) 
		{
			
			SpriteRender.sprite= CatPickedUpSprite;
		}

		if (CatPickedUp == false) 
		{
			SpriteRender.sprite = CatDownSprite;
		}
	}
}
