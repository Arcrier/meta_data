using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparisonItems : MonoBehaviour
{

    private string[][] csv;

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

    }
}
