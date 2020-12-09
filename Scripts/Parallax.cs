using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Position of the sprite in the beginning
        startpos = transform.position.y;
        // The whole extended sprite's height
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        // How far have we moved relative to the camera
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        // Distance measures how far have we gone from our start point.
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);

        if (temp > startpos + length)
        {
            // Check if its a decoration
            if (gameObject.CompareTag("Decoration"))
            {
                Destroy(gameObject);
            }

            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
