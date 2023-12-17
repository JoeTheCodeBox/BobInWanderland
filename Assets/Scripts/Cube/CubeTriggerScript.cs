using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTriggerScript : MonoBehaviour {
    public bool scalesUp = false;
    public bool scalesDown = false;

    private bool isBobOut = true;

    private void OnTriggerEnter(Collider other) {
        if(isBobOut) {
            Animator visual = this.gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Animator>();
            Material material = this.gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Renderer>().material;
            other.gameObject.GetComponent<MaterialChangeScript>().ChangeMaterial(material);
            if (scalesUp) {
                other.gameObject.GetComponent<MovementScript>().ScaleUp();
            }
            if (scalesDown) {
                other.gameObject.GetComponent<MovementScript>().ScaleDown();
            }
            visual.SetTrigger("Activated");
            isBobOut = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isBobOut = true;
    }
}