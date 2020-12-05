using UnityEngine;
using UnityEngine.UI;

public class TextMessage : MonoBehaviour
{
    internal void SetText(string message)
    {
        GetComponent<Text>().text = message;
    }
}