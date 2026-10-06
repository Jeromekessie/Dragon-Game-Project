using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        //throw new System.NotImplementedException();
        Debug.Log("Yo you touch me!");
    }

    public void OnHover()
    {
        Debug.Log("Your looking at me!");
    }

    public void OnHoverExit()
    {
        Debug.Log("You stop looking at me!");
    }

    
}
