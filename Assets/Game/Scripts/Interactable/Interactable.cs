using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected static readonly int shGradRange = Shader.PropertyToID("_GradientRange");

    public SpriteRenderer sprite;

    private PlayerInteractor PlayerInteractor {get; set;}

    public virtual void DoInteraction()
    {
        GameManager.Instance.ChangePlayer();
    }

    public virtual void Select()
    {
        sprite.material.SetFloat(shGradRange, 0);
    }

    public virtual void Unselect()
    {
        sprite.material.SetFloat(shGradRange, 1);
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
