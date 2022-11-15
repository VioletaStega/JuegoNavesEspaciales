using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xwing : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float turnSpeed;

    [Header("Attack")]
    public GameObject bulletPrefab;
    public Transform[] posRotBullet;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Turning();
        Attack();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0, v);

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();

            for (int i = 0; i < posRotBullet.Length; i++)
            {
                Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
            }
        }
    }
}
