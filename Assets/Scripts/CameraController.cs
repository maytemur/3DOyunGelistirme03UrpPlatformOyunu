using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Kamera ile Player'ı takip etmemiz için onun transformunu bilmemiz onu depolayıp erişebileceğimiz bir değişkene ihtiyacımız var
    public Transform playerTransform;
    public Vector3 offset;    

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerTransform.position + offset;
    }
}
