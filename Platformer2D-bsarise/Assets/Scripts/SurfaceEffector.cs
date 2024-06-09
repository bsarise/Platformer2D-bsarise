using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceEffector : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerController controller = rb.GetComponent<PlayerController>();
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();
            if(controller != null)
            {
                controller.MoP = true;
            }

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();
            if(controller != null)
            {
                controller.MoP = false;
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
