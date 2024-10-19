using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Transform leftDoor, rightDoor;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftDoor.DORotate(new Vector3(0,90,0),0.5f);
            rightDoor.DORotate(new Vector3(0, -90, 0), 0.5f);
        }
    }
}
