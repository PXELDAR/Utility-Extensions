using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PXELDAR
{
    public class ExtensionTesting : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(TypeExtensions.ToShortenedBytesString(156845785));
        }
    }
}