using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrolIki : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;

    private Rigidbody rb;
    public float hiz = 1.5f;
    float zamanSayaci = 300;
    int canSayaci = 100;
    bool oyunDevam = true;
    bool oyunTamam = false;

    // Start is called before the first frame update
    void Start()
    {
        can.text = canSayaci + "";
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "Oyunu tamamlayamadınız";
            btn.gameObject.SetActive(true);
        }

        if (zamanSayaci <= 0)
        {
            oyunDevam = false;

        }

    }
    private void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(dikey, 0, -yatay);
            rb.AddForce(kuvvet * hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }


    }

    private void OnCollisionEnter(Collision temasEdilen)
    {
        string objIsmi = temasEdilen.gameObject.name;
        if (objIsmi.Equals("BitisZemin"))
        {
            oyunTamam = true;
            durum.text = "Oyun Tamamlandı. Tebrikler.";
            btn.gameObject.SetActive(true);
        }
        else if (objIsmi.Equals("Duvar"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
            {
                oyunDevam = false;
            }

        }


    }

}