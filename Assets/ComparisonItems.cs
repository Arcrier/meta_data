using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

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
        csv = getCSVData();
    }


    void Update()
    {
        
    }

    private string[][] getCSVData()
    {

        return null;
    }

    public void setUpComparisons(GameObject obj)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject comparisonObject = Instantiate(prefab, transform);
            comparisonObject.transform.position -= new Vector3(0, 0, 0.75f);
            comparisonObject.transform.position += new Vector3(0, 0.15f, 0.375f * i);
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
