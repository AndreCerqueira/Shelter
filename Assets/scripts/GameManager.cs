using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image panel;
    int mult = 1;
    float targetValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());
        targetValue = panel.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, Mathf.Lerp(panel.color.a, targetValue, Time.deltaTime * 5));
    }

    // Create corroutine
    IEnumerator Shake()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            float newTargetValue = panel.color.a - Random.Range(0.01f, 0.03f) * mult;

            if (newTargetValue > 0f && newTargetValue < 0.3f)
            {
                targetValue = newTargetValue;
            }

            if (Random.Range(0, 100) < 20)
                mult *= -1;
        }
    }
}