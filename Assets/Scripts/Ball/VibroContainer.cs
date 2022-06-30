using System.Collections;
using UnityEngine;

public class VibroContainer : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(vibro());
    }

    IEnumerator vibro()
    {
        for (int i = 0; i < 5; i++)
        {
            Vibration.Vibrate(100 * i);
            print(2);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
        Vibration.VibratePop();


        yield return new WaitForSeconds(1f);
        Vibration.VibratePeek();

        yield return new WaitForSeconds(1f);
        Vibration.VibrateNope();

        yield return new WaitForSeconds(1f);

        Vibration.Vibrate();
        yield return new WaitForSeconds(5f);
    }
}
