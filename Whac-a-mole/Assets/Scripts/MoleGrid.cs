using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleGrid : MonoBehaviour
{
    public GameObject moleHole;
    public int width = 4;
    public int height = 4;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(-(width / 2 - 0.5f), 0, -(height / 2 - 0.5f));

        for (int x = 0; x < height; ++x)
        {
            for (int z = 0; z < width; ++z)
            {
                Instantiate(moleHole, this.gameObject.transform.position + new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
