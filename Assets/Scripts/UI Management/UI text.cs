using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] string textCode;

    public void Update()
    {
        textMesh.text = LanguageManager.Instance.GetText(textCode);
    }
}