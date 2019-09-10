using UnityEngine;
using UnityEngine.UI;

public class DualJoystickTouchContoller : MonoBehaviour
{
	public Image leftJoystickBackgroundImage;

	public Image rightJoystickBackgroundImage;

	public bool leftJoystickAlwaysVisible;

	public bool rightJoystickAlwaysVisible;

	private Image leftJoystickHandleImage;

	private Image rightJoystickHandleImage;

	private LeftJoystick leftJoystick;

	private RightJoystick rightJoystick;

	private int leftSideFingerID;

	private int rightSideFingerID;

	private void Start()
	{
		if (leftJoystickBackgroundImage.GetComponent<LeftJoystick>() == null)
		{
			UnityEngine.Debug.LogError("There is no LeftJoystick script attached to the Left Joystick game object.");
		}
		else
		{
			leftJoystick = leftJoystickBackgroundImage.GetComponent<LeftJoystick>();
			leftJoystickBackgroundImage.enabled = leftJoystickAlwaysVisible;
		}
		if (leftJoystick.transform.GetChild(0).GetComponent<Image>() == null)
		{
			UnityEngine.Debug.LogError("There is no left joystick handle image attached to this script.");
		}
		else
		{
			leftJoystickHandleImage = leftJoystick.transform.GetChild(0).GetComponent<Image>();
			leftJoystickHandleImage.enabled = leftJoystickAlwaysVisible;
		}
		if (rightJoystickBackgroundImage.GetComponent<RightJoystick>() == null)
		{
			UnityEngine.Debug.LogError("There is no RightJoystick script attached to Right Joystick game object.");
		}
		else
		{
			rightJoystick = rightJoystickBackgroundImage.GetComponent<RightJoystick>();
			rightJoystickBackgroundImage.enabled = rightJoystickAlwaysVisible;
		}
		if (rightJoystick.transform.GetChild(0).GetComponent<Image>() == null)
		{
			UnityEngine.Debug.LogError("There is no right joystick handle attached to this script.");
			return;
		}
		rightJoystickHandleImage = rightJoystick.transform.GetChild(0).GetComponent<Image>();
		rightJoystickHandleImage.enabled = rightJoystickAlwaysVisible;
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
				if (position.x < (float)(Screen.width / 2))
				{
					leftSideFingerID = touches[i].fingerId;
					if (!leftJoystick.joystickStaysInFixedPosition)
					{
						Vector3 position2 = leftJoystickBackgroundImage.rectTransform.position;
						Vector2 position3 = touches[i].position;
						float x = position3.x;
						Vector2 sizeDelta = leftJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.x = x + sizeDelta.x / 2f;
						Vector2 position4 = touches[i].position;
						float y = position4.y;
						Vector2 sizeDelta2 = leftJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.y = y - sizeDelta2.y / 2f;
						float x2 = position2.x;
						Vector2 sizeDelta3 = leftJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.x = Mathf.Clamp(x2, sizeDelta3.x, Screen.width / 2);
						float y2 = position2.y;
						float num = Screen.height;
						Vector2 sizeDelta4 = leftJoystickBackgroundImage.rectTransform.sizeDelta;
						position2.y = Mathf.Clamp(y2, 0f, num - sizeDelta4.y);
						leftJoystickBackgroundImage.rectTransform.position = position2;
						leftJoystickBackgroundImage.enabled = true;
						leftJoystickBackgroundImage.rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
					}
					else
					{
						Vector2 position5 = touches[i].position;
						float x3 = position5.x;
						Vector3 position6 = leftJoystickBackgroundImage.rectTransform.position;
						if (x3 <= position6.x)
						{
							Vector2 position7 = touches[i].position;
							float x4 = position7.x;
							Vector3 position8 = leftJoystickBackgroundImage.rectTransform.position;
							float x5 = position8.x;
							Vector2 sizeDelta5 = leftJoystickBackgroundImage.rectTransform.sizeDelta;
							if (x4 >= x5 - sizeDelta5.x)
							{
								Vector2 position9 = touches[i].position;
								float y3 = position9.y;
								Vector3 position10 = leftJoystickBackgroundImage.rectTransform.position;
								if (y3 >= position10.y)
								{
									Vector2 position11 = touches[i].position;
									float y4 = position11.y;
									Vector3 position12 = leftJoystickBackgroundImage.rectTransform.position;
									float y5 = position12.y;
									Vector2 sizeDelta6 = leftJoystickBackgroundImage.rectTransform.sizeDelta;
									if (y4 <= y5 + sizeDelta6.y)
									{
										leftJoystickBackgroundImage.enabled = true;
										leftJoystickBackgroundImage.rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
									}
								}
							}
						}
					}
				}
				Vector2 position13 = touches[i].position;
				if (position13.x > (float)(Screen.width / 2))
				{
					rightSideFingerID = touches[i].fingerId;
					if (!rightJoystick.joystickStaysInFixedPosition)
					{
						Vector3 position14 = rightJoystickBackgroundImage.rectTransform.position;
						Vector2 position15 = touches[i].position;
						float x6 = position15.x;
						Vector2 sizeDelta7 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position14.x = x6 + sizeDelta7.x / 2f;
						Vector2 position16 = touches[i].position;
						float y6 = position16.y;
						Vector2 sizeDelta8 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position14.y = y6 - sizeDelta8.y / 2f;
						float x7 = position14.x;
						float num2 = Screen.width / 2;
						Vector2 sizeDelta9 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position14.x = Mathf.Clamp(x7, num2 + sizeDelta9.x, Screen.width);
						float y7 = position14.y;
						float num3 = Screen.height;
						Vector2 sizeDelta10 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
						position14.y = Mathf.Clamp(y7, 0f, num3 - sizeDelta10.y);
						rightJoystickBackgroundImage.rectTransform.position = position14;
						rightJoystickBackgroundImage.enabled = true;
						rightJoystickBackgroundImage.rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
					}
					else
					{
						Vector2 position17 = touches[i].position;
						float x8 = position17.x;
						Vector3 position18 = rightJoystickBackgroundImage.rectTransform.position;
						if (x8 <= position18.x)
						{
							Vector2 position19 = touches[i].position;
							float x9 = position19.x;
							Vector3 position20 = rightJoystickBackgroundImage.rectTransform.position;
							float x10 = position20.x;
							Vector2 sizeDelta11 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
							if (x9 >= x10 - sizeDelta11.x)
							{
								Vector2 position21 = touches[i].position;
								float y8 = position21.y;
								Vector3 position22 = rightJoystickBackgroundImage.rectTransform.position;
								if (y8 >= position22.y)
								{
									Vector2 position23 = touches[i].position;
									float y9 = position23.y;
									Vector3 position24 = rightJoystickBackgroundImage.rectTransform.position;
									float y10 = position24.y;
									Vector2 sizeDelta12 = rightJoystickBackgroundImage.rectTransform.sizeDelta;
									if (y9 <= y10 + sizeDelta12.y)
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
			if (touches[i].phase == TouchPhase.Ended)
			{
				if (touches[i].fingerId == leftSideFingerID)
				{
					leftJoystickBackgroundImage.enabled = leftJoystickAlwaysVisible;
					leftJoystickHandleImage.enabled = leftJoystickAlwaysVisible;
				}
				if (touches[i].fingerId == rightSideFingerID)
				{
					rightJoystickBackgroundImage.enabled = rightJoystickAlwaysVisible;
					rightJoystickHandleImage.enabled = rightJoystickAlwaysVisible;
				}
			}
		}
	}
}
