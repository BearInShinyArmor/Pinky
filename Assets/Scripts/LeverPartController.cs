using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPartController : MonoBehaviour
{
    public GameObject leverIcon;

    public float oscilateAmplitude = 10f;
    public float oscilationSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Oscilate();
    }

    private void Oscilate()
    {
        if (Math.Abs(gameObject.transform.rotation.z) >= oscilateAmplitude)
        {
            oscilationSpeed = -oscilationSpeed;
        }
        gameObject.transform.Rotate(new Vector3(0, 0, oscilationSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        leverIcon.SetActive(true);
        gameObject.SetActive(false);
    }
}
