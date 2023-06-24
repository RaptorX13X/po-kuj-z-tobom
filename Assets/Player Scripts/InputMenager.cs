using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputMenager : MonoBehaviour
{
    public Vector2 input { private set; get; }
    public bool interact { private set; get; }
    public bool yeet { private set; get; }
    public bool glassYeet { private set; get; }
    public Vector3 mousePos;

void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        interact = Input.GetKey(KeyCode.E);
        yeet = Input.GetMouseButton(1);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        glassYeet = Input.GetMouseButton(0);
    }

}
