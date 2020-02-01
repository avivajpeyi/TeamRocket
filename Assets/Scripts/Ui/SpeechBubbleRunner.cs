using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class SpeechBubbleRunner : MonoBehaviour
{
    private TextMeshPro Text;
    [SerializeField] private float AddDelay;

    private StringBuilder SB;
    private WaitForSeconds wait;

    private float StartScale;
    public float ExpandDurataion;

    public AnimationCurve ExpandCurve;
    
    // Start is called before the first frame update
    void Awake()
    {
        Text = GetComponent<TextMeshPro>();
        wait = new WaitForSeconds(AddDelay);
        SB = new StringBuilder(50);
        StartScale = transform.parent.localScale.x;
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(ShowText(text, ExpandDurataion));
    }

    private IEnumerator ShowText(string text, float expandDuration)
    {
        Text.text = "";
        SB.Clear();
        yield return ExpandText(expandDuration);
        yield return TextAdder(text);
    }

    private IEnumerator TextAdder(string text)
    {
        int index = 0;
        while (SB.Length < text.Length)
        {
            SB.Append(text[index]);
            index++;
            Text.text = SB.ToString();
            yield return wait;
        }
    }

    private IEnumerator ExpandText(float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.parent.transform.localScale =
                Vector3.one * ExpandCurve.Evaluate(timeElapsed / duration) * StartScale;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void Hide()
    {
        transform.parent.localScale = Vector3.zero;
    }
}
