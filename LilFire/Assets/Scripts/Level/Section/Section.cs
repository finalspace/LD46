using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public Transform ceiling;
    private bool finished = false;

    public void Finish()
    {
        if (finished) return;

        finished = true;
        EventManager.Event_SectionFinish(this);
    }
}
