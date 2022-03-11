using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public virtual void ObjectFunction()
    {
        Debug.Log("virtualFunction");
    }

    //B3 실험대 조합하는거 때문에 추가했습니다
    public virtual void ItemActive()
    {
        Debug.Log("ItemActive");
    }
    public virtual void ItemDeactive()
    {
        Debug.Log("ItemDeactive");
    }
}
