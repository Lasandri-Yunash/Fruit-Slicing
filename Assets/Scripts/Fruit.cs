using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject _fruitSlicingPrefab;
    public float startForce = 15f;

    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {

            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(_fruitSlicingPrefab, transform.position, rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
            
        }       
    }
}
