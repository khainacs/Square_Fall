using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButtonEffect: MonoBehaviour 
{
    public float scaleAmount = 1.4f; 
    public float scaleSpeed = 200f;

    private Vector3 originalScale;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        originalScale = transform.localScale;
        
        // Thêm event khi bấm
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        StartCoroutine(ScaleEffect());
    }

    IEnumerator ScaleEffect()
    {
        // Phóng to trước
        float elapsed = 0f;
        float scaleUpAmount = 1f / scaleAmount; // Phóng to ngược lại với scaleAmount
        while (elapsed < 0.1f)
        {
            elapsed += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * scaleUpAmount, elapsed);
            yield return null;
        }
        
        // Thu nhỏ lại
        elapsed = 0f;
        while (elapsed < 0.1f)
        {
            elapsed += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(originalScale * scaleUpAmount, originalScale, elapsed);
            yield return null;
        }
        
        transform.localScale = originalScale;
    }
}
