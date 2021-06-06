using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float fuel = 1;
    public float fuelconsumption = 0.1f;
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float speed = 20;
    private float movement;
    public UnityEngine.UI.Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal"); //sprawdzanie czy gracz wciska strzałkę w lewo lub prawo, wyjście trafia do zmiennej movement
        image.fillAmount = fuel;
    }

    private void FixedUpdate()
    {
        if(fuel>0)
        {
            backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);  //dodaje moment obrotowy do obeiktu backTire 
            frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);   
            carRigidbody.AddTorque(-movement * speed * Time.fixedDeltaTime);   
            // fixedDeltaTime - The interval in seconds at which physics and other fixed frame rate updates
        } 
        
        fuel -= fuelconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
        //Mathf.Abs zwraca wartość bezwzględną - tak by cofając również zużywało się paliwo
    } 
}
