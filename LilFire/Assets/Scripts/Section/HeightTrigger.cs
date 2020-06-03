using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeightTrigger : MonoBehaviour
{
    public Section section;

    private void Update()
    {
        if (Player.Instance.transform.position.y > transform.position.y)
        {
            section.Finish();
            Destroy(this);
        }
    }
}
