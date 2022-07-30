using UnityEngine;
using TMPro;

public class isCorrectColor : MonoBehaviour
{
    public void ChangeColor() {
        TextMeshPro mText = gameObject.GetComponent<TextMeshPro>();
        mText.color = new Color32(33,241,42,255);
    }
}
