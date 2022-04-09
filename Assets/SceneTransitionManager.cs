using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    //private Object player;
    public Vector3 destinationRoom;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
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
        IEnumerator coroutine = GoToSceneRoutine(destinationRoom);
        StartCoroutine(coroutine);
    }

    IEnumerator GoToSceneRoutine(Vector3 destination)
    {
        otherRoom = true;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        transform.SetPositionAndRotation(destination, rotation);
        Debug.Log(destination);
        Debug.Log(transform.position);

        fadeScreen.FadeIn();

    }

    public void Return()
    {
        IEnumerator coroutine = Return(originalPosition);
        StartCoroutine(coroutine);
    }

    IEnumerator Return(Vector3 destination)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        character.enabled = false;
        transform.SetPositionAndRotation(destination, originalRotation);
        character.enabled = true;
        Debug.Log(destination);
        Debug.Log(transform.position);

        otherRoom = false;

        fadeScreen.FadeIn();

    }


}
