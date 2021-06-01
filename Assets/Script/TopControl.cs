using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopControl : MonoBehaviour {
    public UnityEngine.UI.Text zaman,can,durum;
    public UnityEngine.UI.Button btn;
    private Rigidbody rg;
     float zamanSayaci=25.0f;
    int canSayaci = 3;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Use this for initialization
    void Start()
    {
        rg = GetComponent<Rigidbody>();//objemizin rigidboysini bağladık
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci = zamanSayaci - Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if(!oyunTamam)
        {
            durum.text = "Oyun Tamamlanamadı";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
        
        
    }
    void FixedUpdate()
    {
        if (oyunDevam&&!oyunTamam) { 
        float dikey = Input.GetAxis("Vertical");//dikey=vertical
        float yatay = Input.GetAxis("Horizontal");//yatay=horizontal
        Vector3 kuvvet = new Vector3(dikey, 0, -yatay);
        rg.AddForce(kuvvet *5);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        string obje = collision.gameObject.name;
        if (obje.Equals("Bitis"))
        {
            print("Oyun Tamamlandı");
            oyunTamam = true;
            durum.text = "Oyun Tamamlandı";
            btn.gameObject.SetActive(true);
        }
        else if(!obje.Equals("Zemin")&&!obje.Equals("LabirentZemin"))
        {
            canSayaci--;
            can.text = canSayaci+"";
            if (canSayaci == 0)
            {
                oyunDevam = false;
            }
        }
       

    }
}
