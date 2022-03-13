using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private PlayerInputActions PlayerInputActions {get; set;}
    private List<Interactable> Interactables = new List<Interactable>();
    
    void Start()
    {
        PlayerInputActions = new PlayerInputActions();
        PlayerInputActions.Enable();
    }

    void Update()
    {
        if(PlayerInputActions.Player.Interact.triggered)
        {
            Interact();
        }
    }

    private void Interact()
    {
        if(Interactables.Count>0)
        {
            var item = Interactables[Interactables.Count - 1];
            item.DoInteraction();
        }
    }

    public void AddInteractable(Interactable interactable)
    {
        if(Interactables.Count>0)
        {
            var item = Interactables[Interactables.Count - 1];
            item.Unselect();
        }

        interactable.Select();

        Interactables.Add(interactable);
    }

    public void RemoveInteractable(Interactable interactable)
    {
        interactable.Unselect();
        
        Interactables.Remove(interactable);

        if(Interactables.Count>0)
        {
            var item = Interactables[Interactables.Count - 1];
            item.Select();
        }
    }
    private void OnDestroy() 
    {
        PlayerInputActions.Disable();
    }
}
