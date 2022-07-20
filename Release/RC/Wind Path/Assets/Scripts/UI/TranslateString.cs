using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TranslateString : MonoBehaviour
{
    public string Key;
    
    private TextMeshProUGUI t;

    private LanguageManager LM;

    private void Start()
    {
        t = GetComponent<TextMeshProUGUI>();

        LM = FindObjectsOfType<LanguageManager>()[0];

        t.text = LM.getStringByKey(Key);
    }


    private void Update()
    {
        Debug.Log(Key);
        t.text = LM.getStringByKey(Key);
    }
}
