using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactuableObject : MonoBehaviour
{
    public BoxCollider2D BoxCollider;
    public UnityEvent actions;
    private GameObject player;
    public void Exectute(){
        actions?.Invoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            player = other.gameObject;

    }
    public void Resume(){
        player.GetComponent<CharacterMovement>().canMove = true;
    }
}
