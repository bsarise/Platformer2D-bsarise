using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStudy : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Rigidbody2D rigi2D;
    public CircleCollider2D coll;
    public Animator animator;
    public AudioSource audi;

       
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigi2D = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
        animator = GetComponentInChildren<Animator>();
        audi = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
