using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutButton : MonoBehaviour
{
    public void checkout()
    {
        Debug.Log("Checkout");
        Application.Quit();
    }
}
