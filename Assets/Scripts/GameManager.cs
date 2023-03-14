using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerController playerKontrol;
    [SerializeField]
    private float baslangicPozisyonuDelay;
    private bool oyunBittimi=false; //ilk başta birşey demezsek zaten false ile başlıyor,aynı anda 2 collider'a çarpma vs gibi 
    //ekstra durumları engellemek için böyle bir kontrol koyduk aslında şu durumda gereksiz
    private int score;
    public TextMeshProUGUI scoreText;
    public Text WinText;
    public GameObject winnerUI;

    // Start is called before the first frame update
    void Start()
    {
        //playerKontrol = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void baslangicRutin() {
        if (oyunBittimi==false) {
            oyunBittimi = true;
            StartCoroutine(BaslangicCoroutine());
        }
    }
    IEnumerator BaslangicCoroutine() {
        playerKontrol.gameObject.SetActive(false);
        yield return new WaitForSeconds(baslangicPozisyonuDelay);
        playerKontrol.transform.position = playerKontrol.respanwPoint;
        playerKontrol.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        score = 0;
        scoreText.text = "PUAN: " + score.ToString();
        playerKontrol.gameObject.SetActive(true);
        oyunBittimi = false;
    }
    public void SkorEkle(int SkorGosterge) {
        score += SkorGosterge;
        scoreText.text = "PUAN: "+score.ToString();
    }
    public void LevelUp() {
        winnerUI.SetActive(true);
        WinText.text = "Seviye Tamamlandı Toplam Puan " + score;
        Invoke("NextLevel", baslangicPozisyonuDelay);
    }
    public void NextLevel() {
        //SceneManager.LoadScene("Level02");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
