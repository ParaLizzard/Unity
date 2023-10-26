using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    public AudioSource src;
    public AudioClip sfx1,sfx2, sfx3;
    [SerializeField]float thrust = 1;
    [SerializeField] float rotate = 10;
    [SerializeField] bool death = false;
    [SerializeField] ParticleSystem success, crashParticles, engine, sidebooster;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
        src.clip=sfx1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!death) { ProcessInput(); }

    }

    void ProcessInput()
    {
        float hor = Input.GetAxis("Horizontal") * rotate * Time.deltaTime;
        transform.Rotate(0, 0, -hor);

        if (Input.GetKey(KeyCode.Space))
        {
            
            if (!src.isPlaying)
            {
                src.Play();
                engine.Play();
                sidebooster.Play();
            }
            rb.AddRelativeForce(Vector3.up * thrust, ForceMode.Acceleration);
        }
        else
        {
            src.Stop();
            engine.Stop();
            sidebooster.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                death = true;
                src.PlayOneShot(sfx2);
                crashParticles.Play();
                break;
            case "Finish":
                Debug.Log("Finished");
                death = true;
                src.PlayOneShot(sfx3);
                success.Play();
                Invoke("ReloadScene", 3.0f);
                break;
            default:
                break;
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
