using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenager : MonoBehaviour
{
    public Vector2 input { private set; get; }
    public bool interact { private set; get; }
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        interact = Input.GetKey(KeyCode.E);
    }

}
