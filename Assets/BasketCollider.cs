using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketCollider : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
void OnCollisionEnter (Collision collisionInfo){
        if(collisionInfo.collider.tag == "food"){

            GameObject obj = collisionInfo.collider.gameObject;
            // Debug.Log(obj.transform.position);
            // Debug.Log(obj.GetComponent<ItemData>().getPlacedLocation());

            var itemData = obj.GetComponent<ItemData>();

            obj.transform.position = itemData.getPlacedLocation();

            GameObject cart = GameObject.Find("CartCanvas");

            /*var myName = obj.name.Substring(0,obj.name.Length-7);
            Debug.Log(itemData.price);         

            GameObject newCartItem = Instantiate(prefab, cart.transform);
            Debug.Log(cart.transform.childCount);
            newCartItem.GetComponent<RectTransform>().localPosition -= new Vector3(0, (200 * (cart.transform.childCount-3)), 0);

            newCartItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = itemData.storeName + " " + myName;
            newCartItem.transform.GetChild(1).gameObject.GetComponent<Text>().text = itemData.price;*/

            cart.GetComponent<MenuTracker>().addItem(obj, prefab);




        }

        // Debug.Log(collisionInfo.collider.gameObject.transform.);
    }

}
