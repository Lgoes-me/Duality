using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameManager GameManager;

    public SpriteRenderer sprite;
    private PlayerInteractor PlayerInteractor {get; set;}

    public virtual void DoInteraction()
    {
        GameManager.ChangePlayer();
        sprite.color = Color.blue;
    }

    public virtual void Select()
    {
        sprite.color = Color.green;
    }

    public virtual void Unselect()
    {
        sprite.color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Interactor"))
        {
            PlayerInteractor = other.GetComponent<PlayerInteractor>();
            PlayerInteractor.AddInteractable(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Interactor"))
        {
            PlayerInteractor.RemoveInteractable(this);
            Unselect();
        }
    }
}
