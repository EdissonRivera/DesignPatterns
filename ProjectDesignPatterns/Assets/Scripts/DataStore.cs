
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface DataStore
{
    void SetData<T>(T data, string name);
    T GetData<T>(string name);
}
