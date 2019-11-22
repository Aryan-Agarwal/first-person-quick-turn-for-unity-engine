using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// you can delete or commnent the audiosource lines
public class Movement : MonoBehaviour
{

    public float moveSpeed = 30.0f;
    public float rotateSpeed = 60.0f;
    public float rot = 0.0f;
    public float smallTurn = 30.0f;

    public AudioClip footSteps = null;

    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        QuickTurn();
        quit();
   
    }

    private void quit()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void QuickTurn()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            //this.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
            //this.transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
            //transform.rotation *= Quaternion.Euler(0, -90, 0);
            transform.rotation *= Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            //this.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            //this.transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
            transform.rotation *= Quaternion.Euler(0, 90, 0);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
            if (!audioSource.isPlaying) //doesn't overlap
            {
                audioSource.PlayOneShot(footSteps);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime));
        }
        else
        {
            audioSource.Stop();
        }
    }
    
}   