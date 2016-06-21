using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour
{
	private LineRenderer lineRenderer;

	public Transform origin;
	public Transform destination;

	void Start ()
	{
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.SetWidth (4f, 4f);
	}

	public void Draw ()
	{
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetPosition (1, destination.position);
	}

	public LineRenderer getLineRenderer ()
	{
		return lineRenderer;
	}
}
