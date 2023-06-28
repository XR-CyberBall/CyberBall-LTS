using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class C_Notification_Panel : MonoBehaviour
{
    public TMP_Text Counter_text;
    private int counterValue;
    private Coroutine countdownCoroutine;
    public TMP_Text notification_text;
    private string text="";

    void Start()
    {
        counterValue = 0;
        active(false);
    }
    public void active(bool val)
    {

        gameObject.SetActive(val);
    }
    void Update()
    {
        Counter_text.text = counterValue.ToString();
        notification_text.text = text;
    }

    public void StartCounter(int secondsToDiscount)
    {
    
        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);

        countdownCoroutine = StartCoroutine(Countdown(secondsToDiscount));
    }
  public void set_notification_message(string _text)
    {

       text = _text;
    }

    private IEnumerator Countdown(int secondsToDiscount)
    {
        counterValue = secondsToDiscount;

        while (counterValue > 0)
        {
            yield return new WaitForSeconds(1f);
            counterValue--;
            Counter_text.text = counterValue.ToString();
            notification_text.text = text;

        }

   
        gameObject.SetActive(false);
        counterValue = 0;
        text = "";
    }
}
