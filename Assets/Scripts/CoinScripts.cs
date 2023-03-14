using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScripts : MonoBehaviour
{
    private GameManager gameManager;
    public int skorDegeri;
    public AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        //skor değerini gamemanager içinde oluşturacağım bir metoda prametre olarak göndereceğiz
        //objeyi yok edeceğiz
        if (other.CompareTag("Player")) {
            gameManager.SkorEkle(skorDegeri);
            coinSound.Play();
            Destroy(this.gameObject);
        }
    }
}
