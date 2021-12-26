using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArabaHareketleri : MonoBehaviour
{
    //Hareket ve H�zlanma De�i�kenleri
    public float movespeed = 50;
    public float maxspeed = 15;
    public float drag = 1;
    //D�nme De�i�kenleri
    public float steerangle = 20;
    //�eki� De�i�kenleri
    public float traction = 1;

    private Vector3 moveforce;

    void Update()
    {
        //Hareket
        moveforce += transform.forward * movespeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += moveforce * Time.deltaTime;

        //D�nme Hareketi
        float steerinput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerinput * moveforce.magnitude * steerangle * Time.deltaTime);


        //H�zlanma ve H�z S�n�r�
        moveforce *= drag;
        moveforce = Vector3.ClampMagnitude(moveforce, maxspeed);

        //Traction
        Debug.DrawRay(transform.position, moveforce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        moveforce = Vector3.Lerp(moveforce.normalized, transform.forward, traction * Time.deltaTime) * moveforce.magnitude;

        
    }
}
