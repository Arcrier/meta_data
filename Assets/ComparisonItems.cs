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
        //setUpComparisons(donut);
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
            switch(i)
            {
                case 0:
                    if (obj.name == "Donuts")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Aldi";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$11.88";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "12 Donuts";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$0.99 / 1 Donut";
                    }
                    else if (obj.name == "HamEgg")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Aldi";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$12.49";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "8";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$1.56 / Sandwich";
                    }
                    break;
                case 1:
                    if (obj.name == "Donuts")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Kroger";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$10.68";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "12 Donuts";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$0.89 / 1 Donut";
                    }
                    else if (obj.name == "HamEgg")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Kroger";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$5.99";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "4";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$1.49 / Sandwich";
                    }
                    break;
                case 2:
                    if (obj.name == "Donuts")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Trader Joe's";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$15.48";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "12 Donuts";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$1.29 / 1 Donut";
                    }
                    else if (obj.name == "HamEgg")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Trader Joe's";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$11.99";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "6";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$2.00 / Sandwich";
                    }
                    break;
                case 3:
                    if (obj.name == "Donuts")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Publix";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$11.88";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "12 Donuts";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$0.99 / 1 Donut";
                    }
                    else if (obj.name == "HamEgg")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Publix";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$12.49";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "8";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$1.56 / Sandwich";
                    }
                    break;
                case 4:
                    if (obj.name == "Donuts")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Walmart";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$9.48";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "12 Donuts";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$0.79 / 1 Donut";
                    }
                    else if (obj.name == "HamEgg")
                    {
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("NameText").GetComponent<Text>().text = "Walmart";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceText").GetComponent<Text>().text = "$11.99";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("AmountText").GetComponent<Text>().text = "8";
                        comparisonObject.GetNamedChild("Canvas").GetNamedChild("PriceAmountText").GetComponent<Text>().text = "$1.49 / Sandwich";
                    }
                    break;
            }
            
            GameObject comparisonSubObject = Instantiate(obj, comparisonObject.transform);
            comparisonSubObject.transform.localPosition = new Vector3(0, -0.15f, 0);
            XRSimpleInteractable interactable = comparisonSubObject.GetComponent<XRSimpleInteractable>();
            if (interactable != null)
            {
                Destroy(interactable);
            }
            comparisonSubObject.AddComponent<XRGrabInteractable>();
        }
    }
}
