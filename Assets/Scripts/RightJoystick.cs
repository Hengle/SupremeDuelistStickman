using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler
{
	[Tooltip("When checked, this joystick will stay in a fixed position.")]
	public bool joystickStaysInFixedPosition;

	[Tooltip("Sets the amount distance of the joystick handle (knob) stays away from the center of this joystick. If the joystick handle doesn't look or feel right you can change this value. Must be a whole number. Default value is 4.")]
	public int joystickHandleDistance = 4;

	private Image bgImage;

	private Image joystickKnobImage;

	private Vector3 inputVector;

	private Vector3 unNormalizedInput;

	private Vector3[] fourCornersArray = new Vector3[4];

	private Vector2 bgImageStartPosition;

	public bool IsTouching;

	private void Start()
	{
		if (GetComponent<Image>() == null)
		{
			UnityEngine.Debug.LogError("There is no joystick image attached to this script.");
		}
		if (base.transform.GetChild(0).GetComponent<Image>() == null)
		{
			UnityEngine.Debug.LogError("There is no joystick handle image attached to this script.");
		}
		if (GetComponent<Image>() != null && base.transform.GetChild(0).GetComponent<Image>() != null)
		{
			bgImage = GetComponent<Image>();
			joystickKnobImage = base.transform.GetChild(0).GetComponent<Image>();
			bgImage.rectTransform.GetWorldCorners(fourCornersArray);
			bgImageStartPosition = fourCornersArray[3];
			bgImage.rectTransform.pivot = new Vector2(1f, 0f);
			bgImage.rectTransform.anchorMin = new Vector2(1f, 0f);
			bgImage.rectTransform.anchorMax = new Vector2(1f, 0f);
			bgImage.rectTransform.position = bgImageStartPosition;
		}
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		IsTouching = true;
		Vector2 localPoint = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, ped.position, ped.pressEventCamera, out localPoint))
		{
			float x = localPoint.x;
			Vector2 sizeDelta = bgImage.rectTransform.sizeDelta;
			localPoint.x = x / sizeDelta.x;
			float y = localPoint.y;
			Vector2 sizeDelta2 = bgImage.rectTransform.sizeDelta;
			localPoint.y = y / sizeDelta2.y;
			inputVector = new Vector3(localPoint.x * 2f + 1f, localPoint.y * 2f - 1f, 0f);
			unNormalizedInput = inputVector;
			inputVector = ((!(inputVector.magnitude > 0.25f)) ? inputVector : (inputVector.normalized / 4f));
			RectTransform rectTransform = joystickKnobImage.rectTransform;
			float x2 = inputVector.x;
			Vector2 sizeDelta3 = bgImage.rectTransform.sizeDelta;
			float x3 = x2 * (sizeDelta3.x / (float)joystickHandleDistance);
			float y2 = inputVector.y;
			Vector2 sizeDelta4 = bgImage.rectTransform.sizeDelta;
			rectTransform.anchoredPosition = new Vector3(x3, y2 * (sizeDelta4.y / (float)joystickHandleDistance));
			if (!joystickStaysInFixedPosition && unNormalizedInput.magnitude > inputVector.magnitude)
			{
				Vector3 position = bgImage.rectTransform.position;
				float x4 = position.x;
				Vector2 delta = ped.delta;
				position.x = x4 + delta.x;
				float y3 = position.y;
				Vector2 delta2 = ped.delta;
				position.y = y3 + delta2.y;
				float x5 = position.x;
				float num = Screen.width / 2;
				Vector2 sizeDelta5 = bgImage.rectTransform.sizeDelta;
				position.x = Mathf.Clamp(x5, num + sizeDelta5.x, Screen.width);
				float y4 = position.y;
				float num2 = Screen.height;
				Vector2 sizeDelta6 = bgImage.rectTransform.sizeDelta;
				position.y = Mathf.Clamp(y4, 0f, num2 - sizeDelta6.y);
				bgImage.rectTransform.position = position;
			}
		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickKnobImage.rectTransform.anchoredPosition = Vector3.zero;
		IsTouching = false;
	}

	public Vector3 GetInputDirection()
	{
		return new Vector3(inputVector.x, inputVector.y, 0f);
	}
}
