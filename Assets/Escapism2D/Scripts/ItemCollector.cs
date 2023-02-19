using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int applesCollected = 0;
    private int bananasCollected = 0;
    private int cherriesCollected = 0;
    private int kiwiesCollected = 0;
    private int melonsCollected = 0;
    private int orangesCollected = 0;
    private int pineapplesCollected = 0;
    private int strawberriesCollected = 0;
    private int pointsCollected = 0;
    [SerializeField] private Text pointsText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Update()
    {
        pointsCollected = (applesCollected*1) + (bananasCollected*2) + (cherriesCollected*3) + (kiwiesCollected*4) + (melonsCollected*5) + (orangesCollected*6) + (pineapplesCollected*7) + (strawberriesCollected*8);
        pointsText.text = "Points: " + pointsCollected.ToString("D3");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Apples"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        applesCollected++;
    }
    
    else if (collision.gameObject.CompareTag("Bananas"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        bananasCollected++;
    }
    else if (collision.gameObject.CompareTag("Cherries"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        cherriesCollected++;
    }
    
    else if (collision.gameObject.CompareTag("Kiwies"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        kiwiesCollected++;
    }
    
    else if (collision.gameObject.CompareTag("Melons"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        melonsCollected++;
    }
    else if (collision.gameObject.CompareTag("Oranges"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        orangesCollected++;
    }
    else if (collision.gameObject.CompareTag("Pineapples"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        pineapplesCollected++;
    }
    else if (collision.gameObject.CompareTag("Strawberries"))
    {
        collectionSoundEffect.Play();
        Destroy(collision.gameObject);
        strawberriesCollected++;
    }
    }


}
