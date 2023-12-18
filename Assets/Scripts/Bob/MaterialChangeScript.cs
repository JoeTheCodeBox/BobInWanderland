using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : MonoBehaviour
{
    public void ChangeMaterial(Material newMaterial) {
        Renderer[] ChildRenderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < ChildRenderers.Length; i ++) {
            ChildRenderers[i].material = newMaterial;
        }
        this.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        AudioSource pop = this.gameObject.GetComponent<AudioSource>();
		pop.Play();
    }
}
