using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    //private Object player;
    public Vector3 destination;
    public Quaternion rotation;
    private CharacterController character;

    public bool otherRoom;

    private void Start()
    {
        otherRoom = false;
        //player = GetComponent<Object>();
        character = GetComponent<CharacterController>();
        //destination = new Vector3(10, 10, 10);
    }

    public void GoToScene()
    {
        IEnumerator coroutine = GoToSceneRoutine(destination);
        StartCoroutine(coroutine);
    }

    IEnumerator GoToSceneRoutine(Vector3 destination)
    {
        otherRoom = true;
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        transform.SetPositionAndRotation(destination, rotation);
        Debug.Log(destination);
        Debug.Log(transform.position);

        fadeScreen.FadeIn();

    }

    
}
