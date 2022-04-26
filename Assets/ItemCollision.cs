using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{

    void OnCollisionEnter (Collision collisionInfo){
        if(collisionInfo.collider.tag == "food"){

            GameObject obj = collisionInfo.collider.gameObject;
            Debug.Log(obj.transform.position);
            Debug.Log(obj.GetComponent<ItemData>().getPlacedLocation());
            obj.transform.position = obj.GetComponent<ItemData>().getPlacedLocation();

        }

        // Debug.Log(collisionInfo.collider.gameObject.transform.);
    }

}
