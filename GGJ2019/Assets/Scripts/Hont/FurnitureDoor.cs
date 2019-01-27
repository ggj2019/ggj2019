using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FurnitureDoor : DescribeTextObject
{
    public int sceneIndex = 2;


    void Update()
    {
        if (Camera.main == null) return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = default(RaycastHit);
        if (Physics.Raycast(ray, out hit, 1 << 8))
        {
            if (Input.GetMouseButtonUp(0))
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
