using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTracker : MonoBehaviour
{
    class MenuItem 
    {

        public int amount;
        public int childIndex;

        public float price;

        public MenuItem(int amount, int childIndex, float price)
        {
            this.amount = amount;
            this.childIndex = childIndex;
            this.price = price;
        }

    }

    Dictionary<string, MenuItem> menuItems;

    void Start()
    {
        menuItems = new Dictionary<string, MenuItem>();
    }

    public void addItem(GameObject obj, GameObject prefab)
    {

        var itemData = obj.GetComponent<ItemData>();

        var myName = itemData.storeName + " " +  obj.name.Substring(0, obj.name.Length - 7);

        if (!menuItems.ContainsKey(myName))
        {
            Debug.Log("New");
            menuItems[myName] = new MenuItem(1, transform.childCount, itemData.price);
            GameObject newCartItem = Instantiate(prefab, transform);
            newCartItem.GetComponent<RectTransform>().localPosition -= new Vector3(0, (200 * (gameObject.transform.childCount - 7)), 0);

            newCartItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = myName;
            newCartItem.transform.GetChild(1).gameObject.GetComponent<Text>().text = itemData.price.ToString("C2");
            newCartItem.transform.GetChild(2).GetChild(0).GetComponent<prefabButtonInteracteable>().myName = myName;
            newCartItem.transform.GetChild(3).GetChild(0).GetComponent<prefabButtonInteracteable>().myName = myName;

        }
        else
        {
            Debug.Log("Not new");
            MenuItem myItem = menuItems[myName];
            myItem.amount += 1;
            transform.GetChild(myItem.childIndex).GetChild(0).gameObject.GetComponent<Text>().text = myName + " x" + myItem.amount;
            transform.GetChild(myItem.childIndex).GetChild(1).gameObject.GetComponent<Text>().text = (itemData.price * myItem.amount).ToString("C2");
        }

        updateTotal();
    }

    public void addQuantity(string myName)
    {
        Debug.Log("Not new");
        MenuItem myItem = menuItems[myName];
        myItem.amount += 1;
        transform.GetChild(myItem.childIndex).GetChild(0).gameObject.GetComponent<Text>().text = myName + " x" + myItem.amount;
        transform.GetChild(myItem.childIndex).GetChild(1).gameObject.GetComponent<Text>().text = (myItem.price * myItem.amount).ToString("C2");
        updateTotal();
    }

    public void removeQuantity(string myName)
    {
        Debug.Log("Not new");
        MenuItem myItem = menuItems[myName];
        myItem.amount -= 1;
        transform.GetChild(myItem.childIndex).GetChild(0).gameObject.GetComponent<Text>().text = myName + " x" + myItem.amount;
        transform.GetChild(myItem.childIndex).GetChild(1).gameObject.GetComponent<Text>().text = (myItem.price * myItem.amount).ToString("C2");

        if (myItem.amount < 1)
        {
            Destroy(transform.GetChild(myItem.childIndex).gameObject);
            menuItems.Remove(myName);
        }

        updateTotal();
    }

    private void updateTotal()
    {
        Text totalText = transform.GetChild(3).gameObject.GetComponent<Text>();
        float total = 0f;
        foreach (KeyValuePair<string, MenuItem> entry in menuItems)
        {
            total += entry.Value.price * entry.Value.amount;
        }
        totalText.text = "Total: " + total.ToString("C2");
    }
}
