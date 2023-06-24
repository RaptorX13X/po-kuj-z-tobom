using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputMenager : MonoBehaviour
{
    public Vector2 input { private set; get; }
    public bool action { private set; get; }
    public Vector3 mousePos;

void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        action = Input.GetKey(KeyCode.E);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }

}
