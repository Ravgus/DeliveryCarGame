using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    public bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    [SerializeField] Color32 hasPackageColor = new Color32(0, 21, 175, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    [SerializeField] public float destroyDelay = 0.1f;

    private void Start() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !this.hasPackage) {
            this.hasPackage = true;

            this.spriteRenderer.color = this.hasPackageColor;

            Debug.Log("Package picked up!");

            Destroy(other.gameObject, this.destroyDelay);
        } else if (other.tag == "Customer" && this.hasPackage) {
            this.hasPackage = false;

            this.spriteRenderer.color = this.noPackageColor;

            Debug.Log("Package delivered!");
        }
    }
}
