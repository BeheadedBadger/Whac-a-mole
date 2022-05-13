using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleGrid : MonoBehaviour
{
    public GameObject moleHole;
    public int height = 4;
    public int width = 3;

    void Start()
    {
        Center();

        //Spawn specified number of gameobjects
        for (int x = 0; x < width; ++x)
        {
            for (int z = 0; z < height; ++z)
            {
                Instantiate(moleHole, this.gameObject.transform.position + new Vector3(x, 0, z), Quaternion.identity);
            }
        }
    }

    //Put grid object in a position that will result in the totality of the spawned objects to appear in the center of the scene
    void Center()
    {
        //Width position calculation if height is even
        if (height % 2 == 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, -((height / 2) - 0.5f));
        }

        //Width position calculation if height is odd
        else
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 0, -(height / 2));
        }

        //Height position calculation if width is even
        if (width % 2 == 0)
        {
            this.gameObject.transform.position = new Vector3(-((width / 2) - 0.5f), 0, this.gameObject.transform.position.z);
        }

        //Height position calculation if width is odd
        else
        {
            this.gameObject.transform.position = new Vector3(-(width / 2), 0, this.gameObject.transform.position.z);
        }
    }
}
