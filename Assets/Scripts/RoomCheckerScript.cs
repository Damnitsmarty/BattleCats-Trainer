using UnityEngine;
using System.Collections;

public class RoomCheckerScript : MonoBehaviour {



	public CattributesScript cattributes;
    public MobileInputScript InputScript;

    public Vector3 CatLockPosition;
   
    bool CatPickedUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CatPickedUp = InputScript.CatPickedUp;
	}


    void OnTriggerEnter(Collider other)
    {
        if (InputScript.CatPickedUp == false)
        {
            if (other.gameObject.tag == "GymLevel1")
            {
                CatLockPosition = other.gameObject.transform.FindChild("CatLock").position;
                cattributes.GymLevel1();
                Debug.Log("Cat placed in Gym");
                

            }


            if (other.gameObject.tag == "GymLevel2")
            {
                CatLockPosition = other.gameObject.transform.FindChild("CatLock").position;
                cattributes.GymLevel2();
                Debug.Log("Cat placed in Gym");
                Debug.Log(CatLockPosition);


            }



            if (other.gameObject.tag == "GymLevel3")
            {
                cattributes.GymLevel3();
                Debug.Log("Cat placed in Gym");
            }







            if (other.gameObject.tag == "TreadMillLevel1")
            {
                cattributes.TreadMillLevel1();
                Debug.Log("Cat placed on the TreadMill");
            }


            if (other.gameObject.tag == "TreadMillLevel2")
            {
                cattributes.TreadMillLevel2();
                Debug.Log("Cat placed on the TreadMill");
            }

            if (other.gameObject.tag == "TreadMillLevel3")
            {
                cattributes.TreadMillLevel3();
                Debug.Log("Cat placed on the TreadMill");
            }



            if (other.gameObject.tag == "LaserRoomLevel1")
            {
                cattributes.ArcadeLevel1();
                Debug.Log("Cat placed in LaserRoom");
            }

            if (other.gameObject.tag == "LaserRoomLevel2")
            {
                cattributes.ArcadeLevel2();
                Debug.Log("Cat placed in LaserRoom");
            }

            if (other.gameObject.tag == "LaserRoomLevel3")
            {
                cattributes.ArcadeLevel3();
                Debug.Log("Cat placed in LaserRoom");
            }





            if (other.gameObject.tag == "KitchenLevel1")
            {
                cattributes.KitchenLevel1();
                Debug.Log("Cat placed in Kitchen");
            }


            if (other.gameObject.tag == "KitchenLevel2")
            {
                cattributes.KitchenLevel2();
                Debug.Log("Cat placed in Kitchen");
            }


            if (other.gameObject.tag == "KitchenLevel3")
            {
                cattributes.KitchenLevel3();
                Debug.Log("Cat placed in Kitchen");
            }

        }
    }

	void OnTriggerExit (Collider other)
	{
		cattributes.InActive ();
		Debug.Log ("The Cat is Inactive");
}
}
