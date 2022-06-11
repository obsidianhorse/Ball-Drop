using UnityEngine;
using UnityEngine.UI;

public class StagePointer : MonoBehaviour
{
    [SerializeField] private RectTransform _contentTransform;
    [SerializeField] private Transform[] _pointers;
    [SerializeField] private RectTransform[] _stages;

    private const float _SizeForCurrentPoint = 1.3f;
    private const float _SizeForCurrentStage = 1.13f;
    private Color32 activePointerColor = new Color32(255, 255, 255, 255);
    private Color32 PointerColor = new Color32(240, 240, 240, 255);


    private void Update()
    {
        RecognizeCurrentPoint();
    }
    private void RecognizeCurrentPoint()
    {
        float xContentPosition = _contentTransform.anchoredPosition.x * -1;
        float delta = _contentTransform.rect.width / _pointers.Length;

        float firstStage = (delta * 0.5f);
        float secondStage = (delta * 1.5f);

        if (xContentPosition <= firstStage)
        {
            SetViewOfCurrentPoint(0);
        }
        else if (xContentPosition > firstStage && xContentPosition < secondStage)
        {
            SetViewOfCurrentPoint(1);
        }
        else
        {
            SetViewOfCurrentPoint(2);
        }

    }
    private void SetViewOfCurrentPoint(int currentPoint)
    {
        for (int i = 0; i < _pointers.Length; i++)
        {
            if (currentPoint == i)
            {
                _pointers[i].localScale = new Vector2(_SizeForCurrentPoint, _SizeForCurrentPoint);
                _pointers[i].GetComponent<Image>().color = activePointerColor;

                _stages[i].localScale = Vector3.one * _SizeForCurrentStage;
            }
            else
            {
                _pointers[i].localScale = Vector2.one;
                _pointers[i].GetComponent<Image>().color = PointerColor;

                _stages[i].localScale = Vector3.one;
            }
        }
    }
    
}
