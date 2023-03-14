using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rigidb;

    [SerializeField]
    public float pushForce;
    private float movement;
    [SerializeField]
    private float hiz;
    public Vector3 respanwPoint;
    [SerializeField]
    private GameManager gameManager;

    public AudioSource crashSound;

    //[SerializeField] private Rigidbody rigidOzel; private olmasına rağmen SerializeField diyince görebiliyoruz
    //[HideInInspector] public Rigidbody rigidSakla; public olmasına rağmen inspector de gözükmez
    // Start is called before the first frame update
    void Start() {
        //rigidb = GetComponent<Rigidbody>(); 
        //arayüzden ekleyebildiğimiz gibi buradan kod ilede böyle ekleyebiliyoruz rigidbody özelliğini çalışınca özelliği alıyor
        respanwPoint = transform.position; //başlangıç pozisyonunu kaydettik
        //gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        movement = Input.GetAxis("Horizontal"); //0 ila 1 arası bir değer döndürür
        Debug.Log(movement);
    }
    private void FixedUpdate() {
        rigidb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        //if (Input.GetButton("d") {
        //    rigidb.AddForce(1, 0, 0); //x ekseninde 1 force uyguladık
        //}
        //bunu yapmak yerine input manager'ı kullanıcaz. Edit/project Settings altında input manager'da axes'i genişletirsek
        //önceden tanımlı bütün klavye vs tuşları var

        rigidb.velocity = new Vector3(movement * hiz, rigidb.velocity.y, rigidb.velocity.z);
        //velocity hız sürat vermek için kullanıyoruz

        dusmeDedektor();
    }
    private void OnCollisionEnter(Collision carpma) {
        //bariyer
        //karakterim geri döncek başlangıç pozisyonuna
        if (carpma.collider.CompareTag("Bariyer")) {
            //carpma=="tag" diğer yöntem
            //transform.position = respanwPoint; bunu delay ile gamemanager içinden başlatıyoruz
            gameManager.baslangicRutin();
            crashSound.Play();
        }
    }
    private void dusmeDedektor() {
        if (rigidb.position.y<-2f) {
            gameManager.baslangicRutin();
        }
    }
    private void OnTriggerEnter(Collider other) {
        //Etkileşim gerçekleştiğinde yeni level geçiş metodunu aktive edeceğiz
        if(other.CompareTag("EndTrigger")) {
            gameManager.LevelUp();
        }
    }
}
