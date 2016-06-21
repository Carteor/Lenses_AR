using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject candle;
	public GameObject convex;
	public GameObject screen;
	public Text objectDistanceText;
	public Text imageDistanceText;
	public Text focalLengthText;
	public SimpleLiteMBehaviour camera;
	public DrawLine redLine;
	public DrawLine greenLine;

	//object distance - candle-convex - u
	//image distance - convex-screen - v
	//focal length - f
	private float u;
	private float v;
	private float f;
	private GameObject image;

	void Start ()
	{
		image = GameObject.FindGameObjectWithTag ("Image");
		u = getU ();
		v = getV ();
		f = getF ();
	}

	void Update ()
	{
		u = getU ();
		v = getV ();
		f = getF ();

		if (CanResize ()) {
			image.SetActive (true);
//			Debug.Log ("u: " + u + "\nv: " + v + "\nf: " + f);
			Resize (v / u);

		} else {
			image.SetActive (false);

		}
		SetDistance ();
	}

	float getU ()
	{
		return Vector3.Distance (candle.transform.position, convex.transform.position);
	}

	float getV ()
	{
		return Vector3.Distance (convex.transform.position, screen.transform.position);
	}

	float getF ()
	{
		return getU () * getV () / (getU () + getV ());
	}

	float GetDistance ()
	{
		return Vector3.Distance (candle.transform.position, screen.transform.position);
	}

	void Resize (float scale)
	{
		image.transform.localScale = new Vector3 (scale, scale, scale);
	}

	bool CanResize ()
	{
		if ((u > GetDistance () || v > GetDistance ()) || (v / u < 0) || (v / u > 2)) {
			return false;
		} else {
			return true;
		}
	}

	void SetDistance ()
	{
		if (camera.IsInRange ()) {
			objectDistanceText.text = "Object distance: " + Mathf.Round (getU ()) + " mm";
			imageDistanceText.text = "Image distance: " + Mathf.Round (getV ()) + " mm";
			focalLengthText.text = "Focal length: " + Mathf.Round (getF ()) + " mm";
			redLine.enabled = true;
			greenLine.enabled = true;
			redLine.Draw ();
			greenLine.Draw ();
		} else {
			redLine.enabled = false;
			greenLine.enabled = false;
			objectDistanceText.text = "Object distance: 0 mm";
			imageDistanceText.text = "Image distance: 0 mm";
			focalLengthText.text = "Focal length: 0 mm";
		}
	}
}