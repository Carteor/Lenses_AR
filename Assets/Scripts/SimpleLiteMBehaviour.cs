using UnityEngine;
using System;
using System.Collections;
using jp.nyatla.nyartoolkit.cs.markersystem;
using jp.nyatla.nyartoolkit.cs.core;
using NyARUnityUtils;
using System.IO;

/// <summary>
/// AR camera behaviour.
/// This sample shows simpleLite demo.
/// 1.Connect webcam to your computer.
/// 2.Start sample program
/// 3.Take a "HIRO" marker and "KANJI" on capture image
///
/// </summary>
public class SimpleLiteMBehaviour : MonoBehaviour
{
	private bool isInRange = false;
	private NyARUnityMarkerSystem _ms;
	private NyARUnityWebCam _ss;
	private int mid1;
	//marker id
	private int mid2;
	//marker id
	private int mid3;
	private GameObject _bg_panel;

	void Awake ()
	{
		//setup unity webcam
		WebCamDevice[] devices = WebCamTexture.devices;
		
		if (devices.Length <= 0) {
			Debug.LogError ("No Webcam.");
			return;
		}
		WebCamTexture w = new WebCamTexture (320, 240, 15);
		//Make WebcamTexture wrapped Sensor.
		this._ss = NyARUnityWebCam.createInstance (w);
		//Make configulation by Sensor size.
		NyARMarkerSystemConfig config = new NyARMarkerSystemConfig (this._ss.width, this._ss.height);

		this._ms = new NyARUnityMarkerSystem (config);
		mid1 = this._ms.addARMarker (
			new StreamReader (new MemoryStream (((TextAsset)Resources.Load ("candle_marker64", typeof(TextAsset))).bytes)),
			16, 25, 80);
		mid2 = this._ms.addARMarker (
			new StreamReader (new MemoryStream (((TextAsset)Resources.Load ("convex_marker64", typeof(TextAsset))).bytes)),
			16, 25, 80);
		mid3 = this._ms.addARMarker (
			new StreamReader (new MemoryStream (((TextAsset)Resources.Load ("screen_marker64", typeof(TextAsset))).bytes)),
			16, 25, 80);

		//setup background
		this._bg_panel = GameObject.Find ("Plane");
		this._bg_panel.GetComponent<Renderer> ().material.mainTexture = w;
		this._ms.setARBackgroundTransform (this._bg_panel.transform);
		
		//setup camera projection
		this._ms.setARCameraProjection (this.GetComponent<Camera> ());
		return;

	}
	// Use this for initialization
	void Start ()
	{
		//start sensor
		this._ss.start ();
	}
	// Update is called once per frame
	void Update ()
	{
		//Update SensourSystem
		this._ss.update ();
		//Update marker system by ss
		this._ms.update (this._ss);
		//update Gameobject transform
		if (this._ms.isExistMarker (mid1)) {
			this._ms.setMarkerTransform (mid1, GameObject.Find ("MarkerObject").transform);
		} else {
			// hide Game object
			GameObject.Find ("MarkerObject").transform.localPosition = new Vector3 (-50, 0, -100);
		}
		if (this._ms.isExistMarker (mid2)) {
			this._ms.setMarkerTransform (mid2, GameObject.Find ("MarkerObject2").transform);
		} else {
			// hide Game object
			GameObject.Find ("MarkerObject2").transform.localPosition = new Vector3 (0, 0, -100);
		}
		if (this._ms.isExistMarker (mid3)) {
			this._ms.setMarkerTransform (mid3, GameObject.Find ("MarkerObject3").transform);
		} else {
			// hide Game object
			GameObject.Find ("MarkerObject3").transform.localPosition = new Vector3 (50, 0, -100);
		}

		if (this._ms.isExistMarker (mid1) && this._ms.isExistMarker (mid2) && this._ms.isExistMarker (mid3)) {
			isInRange = true;
		} else {
			isInRange = false;
		}
	}

	public bool IsInRange ()
	{
		return isInRange;
	}
}
