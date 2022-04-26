using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.UI;

    public class ItemData : MonoBehaviour{
        public Vector3 placedLocation;
        public string storeName;
        public string price;

        public Vector3 getPlacedLocation()
    {
        return placedLocation;
    }
    }


public class ComparisonItems : MonoBehaviour
{

    private string[][] csv;
    public GameObject prefab;
    public GameObject donut;

    private class Food
    {
        public class ComparisonFood
        {

            public class NutritionFacts 
            { 
                
            }

            NutritionFacts nutrition;
            float price;
            int quantity;
            string quantityUnit;


        }

        public ComparisonFood[] comparisonFoods;
    }


    void Start()
    {
        //csv = getCSVData();
        setUpComparisons(donut);
    }


    void Update()
    {
        
    }

    private string[][] getCSVData()
    {
        string[][] priceArray = File.ReadLines("Assets/FoodPrice.csv").Select(line => Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")).ToArray();
        return priceArray;
    }

    public void setUpComparisons(GameObject obj)
    {
        List<GameObject> childList = new List<GameObject>();
        for(int i = 0; i < transform.childCount; i ++) {
            childList.Add(transform.GetChild(i).gameObject);
        }
        foreach(GameObject child in childList) {
            Destroy(child);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject comparisonObject = Instantiate(prefab, transform);
            comparisonObject.transform.position -= new Vector3(0, 0, 0.75f);
            comparisonObject.transform.position += new Vector3(0, 0.15f, 0.375f * i);

            GameObject canvas = comparisonObject.GetNamedChild("Canvas");
            float price = 0;
            int quantity = 0;
            string quantityMeasure = "";
            
            switch(obj.name)
            {
                case "Donuts":
                    price = 11.88f;
                    quantity = 12;
                    quantityMeasure = "donuts";
                    break;
                case "HamEgg":
                    price = 12.49f;
                    quantity = 8;
                    quantityMeasure = "";
                    break;
                case "IceCream":
                    price = 6.49f;
                    quantity = 128;
                    quantityMeasure = "oz";
                    break;
                case "Waffle":
                    price = 3.59f;
                    quantity = 10;
                    quantityMeasure = "waffles";
                    break;
                case "Cake":
                    price = 17.99f;
                    quantity = 4;
                    quantityMeasure = "lb";
                    break;
                case "Hamburger":
                    price = 14.49f;
                    quantity = 6;
                    quantityMeasure = "burgers";
                    break;
                case "Milk":
                    price = 3.82f;
                    quantity = 1;
                    quantityMeasure = "gallon";
                    break;
                case "Coke":
                    price = 6.79f;
                    quantity = 12;
                    quantityMeasure = "cans";
                    break;
                case "Pepsi":
                    price = 6.79f;
                    quantity = 12;
                    quantityMeasure = "cans";
                    break;
                case "Coke (1)":
                    price = 3.99f;
                    quantity = 6;
                    quantityMeasure = "cans";
                    break;
                case "Pepsi (4)":
                    price = 3.99f;
                    quantity = 6;
                    quantityMeasure = "cans";
                    break;
                case "Pepsi (1)":
                    price = 6.99f;
                    quantity = 12;
                    quantityMeasure = "cans";
                    break;
                case "Pepsi (2)":
                    price = 5.49f;
                    quantity = 12;
                    quantityMeasure = "cans";
                    break;
                case "Pepsi (3)":
                    price = 4.99f;
                    quantity = 12;
                    quantityMeasure = "cans";
                    break;
                case "Tempura":
                    price = 14.49f;
                    quantity = 32;
                    quantityMeasure = "oz";
                    break;
                case "Tacos":
                    price = 7.49f;
                    quantity = 12;
                    quantityMeasure = "tacos";
                    break;
                case "Steak_Uncooked":
                    price = 18.82f;
                    quantity = 2;
                    quantityMeasure = "lb";
                    break;
                case "Steak_Cooked":
                    price = 25.49f;
                    quantity = 32;
                    quantityMeasure = "patties";
                    break;
                case "Shrimp":
                    price = 6.99f;
                    quantity = 12;
                    quantityMeasure = "oz";
                    break;
                case "Sausage":
                    price = 9.42f;
                    quantity = 32;
                    quantityMeasure = "oz";
                    break;
                case "Pizza":
                    price = 6.78f;
                    quantity = 2;
                    quantityMeasure = "lb";
                    break;
                case "Omelette":
                    price = 11.25f;
                    quantity = 56;
                    quantityMeasure = "oz";
                    break;
                case "MeatBall":
                    price = 12.50f;
                    quantity = 10;
                    quantityMeasure = "skewer";
                    break;
                case "Saucisson":
                    price = 4.24f;
                    quantity = 16;
                    quantityMeasure = "oz";
                    break;
                case "HotDog":
                    price = 2.58f;
                    quantity = 6;
                    quantityMeasure = "hot dog";
                    break;
                case "Chicken":
                    price = 6.79f;
                    quantity = 5;
                    quantityMeasure = "lb";
                    break;
                case "SweetPepper":
                    price = 1.48f;
                    quantity = 1;
                    quantityMeasure = "pepper";
                    break;
                case "Salad":
                    price = 1.67f;
                    quantity = 1;
                    quantityMeasure = "head";
                    break;
                case "Pepper":
                    price = 0.64f;
                    quantity = 1;
                    quantityMeasure = "pepper";
                    break;
                case "Mushroom":
                    price = 3.99f;
                    quantity = 12;
                    quantityMeasure = "oz";
                    break;
                case "Coconut":
                    price = 2.34f;
                    quantity = 1;
                    quantityMeasure = "coconut";
                    break;
                case "Watermelon":
                    price = 3.82f;
                    quantity = 1;
                    quantityMeasure = "watermelon";
                    break;
                case "Tomato":
                    price = 1.91f;
                    quantity = 1;
                    quantityMeasure = "lb";
                    break;
                case "Pineapple":
                    price = 1.99f;
                    quantity = 1;
                    quantityMeasure = "pineapple";
                    break;
                case "Onion":
                    price = 1.99f;
                    quantity = 3;
                    quantityMeasure = "lb";
                    break;
                case "Banana":
                    price = 1.69f;
                    quantity = 3;
                    quantityMeasure = "lb";
                    break;
                case "Avocado":
                    price = 1.43f;
                    quantity = 1;
                    quantityMeasure = "avocado";
                    break;
                case "Croissant":
                    price = 11.25f;
                    quantity = 56;
                    quantityMeasure = "oz";
                    break;
                case "Eclair_Chocolate":
                    price = 12.50f;
                    quantity = 10;
                    quantityMeasure = "skewer";
                    break;
                case "Bread":
                    price = 4.24f;
                    quantity = 16;
                    quantityMeasure = "oz";
                    break;
                case "Toast":
                    price = 2.58f;
                    quantity = 6;
                    quantityMeasure = "hot dog";
                    break;
                case "Pizza2":
                    price = 6.79f;
                    quantity = 5;
                    quantityMeasure = "lb";
                    break;
                case "IceCream_Cone":
                    price = 1.48f;
                    quantity = 1;
                    quantityMeasure = "pepper";
                    break;
                case "Muffin":
                    price = 1.67f;
                    quantity = 1;
                    quantityMeasure = "head";
                    break;
                case "IceCreamPop":
                    price = 0.64f;
                    quantity = 1;
                    quantityMeasure = "pepper";
                    break;
                case "Cheese_01":
                    price = 3.99f;
                    quantity = 12;
                    quantityMeasure = "oz";
                    break;
                case "Gyoza":
                    price = 2.34f;
                    quantity = 1;
                    quantityMeasure = "coconut";
                    break;
                case "Cheese_02":
                    price = 3.82f;
                    quantity = 1;
                    quantityMeasure = "watermelon";
                    break;
                case "Rice_Bowl":
                    price = 1.91f;
                    quantity = 1;
                    quantityMeasure = "lb";
                    break;
                case "Sushi":
                    price = 1.99f;
                    quantity = 1;
                    quantityMeasure = "pineapple";
                    break;
                case "Onigiri":
                    price = 1.99f;
                    quantity = 3;
                    quantityMeasure = "lb";
                    break;
                case "Mochi":
                    price = 1.69f;
                    quantity = 3;
                    quantityMeasure = "lb";
                    break;
                case "Maki":
                    price = 1.43f;
                    quantity = 1;
                    quantityMeasure = "avocado";
                    break;
                default:
                    break;
            }

            GameObject comparisonSubObject = Instantiate(obj, comparisonObject.transform);
            comparisonSubObject.tag = "food";
            comparisonSubObject.transform.localPosition = new Vector3(0, -0.15f, 0);
            XRSimpleInteractable interactable = comparisonSubObject.GetComponent<XRSimpleInteractable>();
            if (interactable != null)
            {
                Destroy(interactable);
            }
            comparisonSubObject.AddComponent<XRGrabInteractable>();
            comparisonSubObject.AddComponent<ItemData>();

            var data = comparisonSubObject.GetComponent<ItemData>();
            data.placedLocation = comparisonSubObject.transform.position;
            
            switch(i)
            {
                case 0:
                    canvas.GetNamedChild("NameText").GetComponent<Text>().text = "Aldi";
                    data.storeName = "Aldi";
                    canvas.GetNamedChild("PriceText").GetComponent<Text>().text = price.ToString("C2");
                    canvas.GetNamedChild("AmountText").GetComponent<Text>().text = quantity + " " + quantityMeasure;
                    canvas.GetNamedChild("PriceAmountText").GetComponent<Text>().text = (price / quantity).ToString("C2") + " / 1";
                    break;
                case 1:
                    price -= price * 0.05f;
                    canvas.GetNamedChild("NameText").GetComponent<Text>().text = "Kroger";
                    data.storeName = "Kroger";
                    canvas.GetNamedChild("PriceText").GetComponent<Text>().text = price.ToString("C2");
                    canvas.GetNamedChild("AmountText").GetComponent<Text>().text = quantity + " " + quantityMeasure;
                    canvas.GetNamedChild("PriceAmountText").GetComponent<Text>().text = (price / quantity).ToString("C2") + " / 1";
                    break;
                case 2:
                    price += price * 0.2f;
                    canvas.GetNamedChild("NameText").GetComponent<Text>().text = "Trader Joe's";
                    data.storeName = "Trader Joe's";
                    canvas.GetNamedChild("PriceText").GetComponent<Text>().text = price.ToString("C2");
                    canvas.GetNamedChild("AmountText").GetComponent<Text>().text = quantity + " " + quantityMeasure;
                    canvas.GetNamedChild("PriceAmountText").GetComponent<Text>().text = (price / quantity).ToString("C2") + " / 1";
                    break;
                case 3:
                    if (quantity > 1)
                    {
                        quantity /= 2;
                        price /= 1.8f;
                    }
                    else
                    {
                        price += price * 0.1f;
                    }
                    canvas.GetNamedChild("NameText").GetComponent<Text>().text = "Publix";
                    data.storeName = "Publix";
                    canvas.GetNamedChild("PriceText").GetComponent<Text>().text = price.ToString("C2");
                    canvas.GetNamedChild("AmountText").GetComponent<Text>().text = quantity + " " + quantityMeasure;
                    canvas.GetNamedChild("PriceAmountText").GetComponent<Text>().text = (price / quantity).ToString("C2") + " / 1";
                    break;
                case 4:
                    price -= price * 0.1f;
                    canvas.GetNamedChild("NameText").GetComponent<Text>().text = "Walmart";
                    data.storeName = "Walmart";
                    canvas.GetNamedChild("PriceText").GetComponent<Text>().text = price.ToString("C2");
                    canvas.GetNamedChild("AmountText").GetComponent<Text>().text = quantity + " " + quantityMeasure;
                    canvas.GetNamedChild("PriceAmountText").GetComponent<Text>().text = (price / quantity).ToString("C2") + " / 1";
                    break;
            }

            data.price = price.ToString("C2");
            



        }
    }
}
