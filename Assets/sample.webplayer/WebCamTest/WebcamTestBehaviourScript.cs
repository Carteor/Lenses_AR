using UnityEngine;
using System.Collections;

public class WebcamTestBehaviourScript : MonoBehaviour {


    IEnumerator Start ()
    {
            //Show Authrizatton dialog box.
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            //иЁ±еЏЇгЃЊе‡єг‚ЊгЃ°WebCamTextureг‚’дЅїз”ЁгЃ™г‚‹
            if (Application.HasUserAuthorization (UserAuthorization.WebCam)) {
                    WebCamTexture w = new WebCamTexture ();
                    //MaterialгЃ«гѓ†г‚Їг‚№гѓЃгѓЈг‚’иІјг‚Љд»гЃ‘
                    GetComponent<Renderer>().material.mainTexture = w;
                    //е†Ќз”џ
                    w.Play ();
            }
    }
}
