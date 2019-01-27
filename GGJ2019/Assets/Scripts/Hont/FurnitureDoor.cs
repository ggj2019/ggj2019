using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FurnitureDoor : DescribeTextObject
{
    public int sceneIndex = 2;
    bool mHit1;


    void Aawake()
    {
        mHit1 = false;
    }

    void Update()
    {
        if (Camera.main == null) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = default(RaycastHit);
        if (Physics.Raycast(ray, out hit, 1 << 8))
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (mHit1)
                    SceneManager.LoadScene(sceneIndex);
                mHit1 = true;
            }
        }
    }
}
