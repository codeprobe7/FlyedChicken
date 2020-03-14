using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    [Header("Variables")]
    public float movementSpeed = 10f;
    public float explosionforce = 0f;
    public float explosionRadius = 1f;
    public float powerMultiplier = 15f;
    public static float powerClamp = 8f;
    public float indicatorRadius;

    [Header("Objects")]
    public GameObject rocket;
    public Material rageMat;

    [Header("indicator")]
    public Canvas indicator;
    public Vector3 indicatorOffset;

    [Header("Inspectation")]

    public bool isReadyToFly = false;
    public bool isOnGround;
    public InputTypes inputType;
    public bool isRightStickControlling = false;

    [Header("Sounds")]
    public AudioSource jumpSound;

    private Rigidbody rb;
    private BoxCollider footCollsion;
    private Animator anim;
    
    // update
    void Start()
    {
        rocket.SetActive(true);
        HideIndicator();
        rb = transform.GetComponent<Rigidbody>();
        footCollsion = transform.GetComponent<BoxCollider>();
        anim = transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Ray ray = new Ray(transform.position, Vector3.down);
        //if (Physics.Raycast(ray, 1f, LayerMask.GetMask("Ground")))

        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0f)
        {
            StickLeftContorll(h);
        }
        else Animating(0f);
    }

    private void FixedUpdate() { }

    public void StickLeftContorll(float horizontal)
    {
        if (isRightStickControlling) return;
        if (isOnGround == false) return;
        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        MoveCharacter(movement);
        Animating(horizontal);
    }

    public void StickleftControllEnd()
    {
        Animating(0f);
    }
    public void StickRightControll(Vector3 direction)
    {
        isRightStickControlling = true;
        if (isOnGround)
        {
            indicator.gameObject.SetActive(true);
            indicator.transform.position = transform.position + (direction * indicatorRadius);
        }
        explosionforce = Vector3.Magnitude(indicator.transform.position - transform.position);
        explosionforce *= powerMultiplier;
        isReadyToFly = true;
        Animating(0f);
        Animating(isReadyToFly);
    }
    public void StickRightControllEnd()
    {
        if(isOnGround) Launch();
        isRightStickControlling = false;
        isReadyToFly = false;
        Animating(isReadyToFly);
    }

    private void MoveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }

    private void Animating(float h)
    {
        bool walking = h != 0f ? true : false;
        anim.SetBool("walking", walking);
        if (h != 0f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, 0));
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void Animating(bool readyToFly)
    {
        anim.SetBool("readyToFly", readyToFly);
    }

    public void Launch()
    {
        Animating(0f);
        Showindicator();
        indicator.transform.position = transform.position;
        rb.AddExplosionForce(explosionforce, rocket.transform.position, explosionRadius, 0f, ForceMode.Impulse);
        jumpSound.Play();
        isReadyToFly = false;
        Invoke("HideIndicator", 1f);
    }

    public void HideIndicator()
    {
        indicator.gameObject.SetActive(false);
    }

    public void Showindicator()
    {
        indicator.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        isOnGround = true;
    }

    private void OnTriggerStay(Collider other)
    {
        isOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOnGround = false;
    }

}