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

    public GameObject menuItemPrefab;

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
        }
        else
        {
            MenuItem myItem = menuItems[myName];
            myItem.amount += 1;
        }
        regenMenu();
        updateTotal();
    }

    public void addQuantity(string myName)
    {
        if (menuItems.ContainsKey(myName)) {
            MenuItem myItem = menuItems[myName];
            myItem.amount += 1;
        }
        regenMenu();
        updateTotal();
    }

    public void removeQuantity(string myName)
    {
        if (menuItems.ContainsKey(myName)) {
            MenuItem myItem = menuItems[myName];
            myItem.amount -= 1;

            if (myItem.amount < 1)
            {
                menuItems.Remove(myName);
            }
        }
        
        regenMenu();
        updateTotal();
    }

    private void regenMenu() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i > 3)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        int offset = 0;
        foreach (KeyValuePair<string, MenuItem> entry in menuItems)
        {
            GameObject newCartItem = Instantiate(menuItemPrefab, transform);
            newCartItem.GetComponent<RectTransform>().localPosition = Vector3.zero + new Vector3(200, 1273, 0);
            
            
            newCartItem.GetComponent<RectTransform>().localPosition += new Vector3(0, offset, 0);
            offset -= 500;
            

            newCartItem.transform.GetChild(0).gameObject.GetComponent<Text>().text = entry.Key + " x" + entry.Value.amount;
            newCartItem.transform.GetChild(1).gameObject.GetComponent<Text>().text = (entry.Value.price * entry.Value.amount).ToString("C2");
            newCartItem.transform.GetChild(2).GetChild(0).GetComponent<prefabButtonInteracteable>().myName = entry.Key;
            newCartItem.transform.GetChild(3).GetChild(0).GetComponent<prefabButtonInteracteable>().myName = entry.Key;
        }
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
