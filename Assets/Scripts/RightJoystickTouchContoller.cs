using UnityEngine;
using UnityEngine.UI;

public class RightJoystickTouchContoller : MonoBehaviour
{
	public Image rightJoystickBackgroundImage;

	public bool rightJoyStickAlwaysVisible;

	private Image rightJoystickHandleImage;

	private RightJoystick rightJoystick;

	private int rightSideFingerID;

	private void Start()
	{
		if (rightJoystickBackgroundImage.GetComponent<RightJoystick>() == null)
		{
			UnityEngine.Debug.LogError("There is no RightJoystick script attached to Right Joystick game object.");
		}
		else
		{
			rightJoystick = rightJoystickBackgroundImage.GetComponent<RightJoystick>();
			rightJoystickBackgroundImage.enabled = rightJoyStickAlwaysVisible;
		}
		if (rightJoystick.transform.GetChild(0).GetComponent<Image>() == null)
		{
			UnityEngine.Debug.LogError("There is no right joystick handle attached to this script.");
			return;
		}
		rightJoystickHandleImage = rightJoystick.transform.GetChild(0).GetComponent<Image>();
		rightJoystickHandleImage.enabled = rightJoyStickAlwaysVisible;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (UnityEngine.Input.touchCount <= 0)
		{
			return;
		}
		Touch[] touches = Input.touches;
		for (int i = 0; i < UnityEngine.Input.touchCount; i++)
		{
			if (touches[i].phase == TouchPhase.Began)
			{
				Vector2 position = touches[i].position;
				if (position.x > (float)(Screen.width / 2))
				{
					rightSideFingerID = touches[i].fingerId;
					if (!rightJoystick.joystickStaysInFixedPosition)
					{
						Vector3 position2 = rightJoystickBackgroundImage.rectTransform.position;
						Vector2 position3 = touches[i].position;
						float x = position3.x;
						Vector2 sizeDelta = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.x = x + sizeDelta.x / 2f;
						Vector2 position4 = touches[i].position;
						float y = position4.y;
						Vector2 sizeDelta2 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.y = y - sizeDelta2.y / 2f;
						float x2 = position2.x;
						float num = Screen.width / 2;
						Vector2 sizeDelta3 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.x = Mathf.Clamp(x2, num + sizeDelta3.x, Screen.width);
						float y2 = position2.y;
						float num2 = Screen.height;
						Vector2 sizeDelta4 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.y = Mathf.Clamp(y2, 0f, num2 - sizeDelta4.y);
						rightJoystickBackgroundImage.rectTransform.position = position2;
						rightJoystickBackgroundImage.enabled = true;
						rightJoystickBackgroundImage.rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
					}
					else
					{
						Vector2 position5 = touches[i].position;
						float x3 = position5.x;
						Vector3 position6 = rightJoystickBackgroundImage.rectTransform.position;
						if (x3 <= position6.x)
						{
							Vector2 position7 = touches[i].position;
							float x4 = position7.x;
							Vector3 position8 = rightJoystickBackgroundImage.rectTransform.position;
							float x5 = position8.x;
							Vector2 sizeDelta5 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
							if (x4 >= x5 - sizeDelta5.x)
							{
								Vector2 position9 = touches[i].position;
								float y3 = position9.y;
								Vector3 position10 = rightJoystickBackgroundImage.rectTransform.position;
								if (y3 >= position10.y)
								{
									Vector2 position11 = touches[i].position;
									float y4 = position11.y;
									Vector3 position12 = rightJoystickBackgroundImage.rectTransform.position;
									float y5 = position12.y;
									Vector2 sizeDelta6 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
									if (y4 <= y5 + sizeDelta6.y)
									{
										rightJoystickBackgroundImage.enabled = true;
										rightJoystickBackgroundImage.rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
									}
								}
							}
						}
					}
				}
			}
			if (touches[i].phase == TouchPhase.Ended && touches[i].fingerId == rightSideFingerID)
			{
				rightJoystickBackgroundImage.enabled = rightJoyStickAlwaysVisible;
				rightJoystickHandleImage.enabled = rightJoyStickAlwaysVisible;
			}
		}
	}
}
