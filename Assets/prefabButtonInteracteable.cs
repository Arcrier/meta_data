using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class prefabButtonInteracteable : XRSimpleInteractable
{
    public string myName;

    public bool plus;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject cart = GameObject.Find("CartCanvas");
        if (plus)
        {
            cart.GetComponent<MenuTracker>().addQuantity(myName);
        }
        else
        {
            cart.GetComponent<MenuTracker>().removeQuantity(myName);
        }
        
        base.OnSelectEntered(args);
    }
}
