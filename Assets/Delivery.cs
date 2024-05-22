using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float DestroyTime = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Bumped In!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Delivery" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Delivery Loaded");
            Destroy(other.gameObject, DestroyTime);
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;

        }
    }
}
