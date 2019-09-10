using UnityEngine;

public class MovibleObject : MonoBehaviour
{
	public Vector2 Moove1;

	public int time1Max;

	public int time1Actual;

	public Vector2 Moove2;

	public int time2Max;

	public int time2Actual;

	public int timePauseMax;

	public int timePauseActual;

	public int state;

	private void Start()
	{
		state = 3;
		time1Actual = time1Max;
		time2Actual = time2Max;
		timePauseActual = timePauseMax;
	}

	public void OnEnable()
	{
		state = 3;
		time1Actual = time1Max;
		time2Actual = time2Max;
		timePauseActual = timePauseMax;
	}

	private void FixedUpdate()
	{
		switch (state)
		{
		case 3:
			timePauseActual--;
			if (timePauseActual <= 0)
			{
				state = 1;
				time1Actual = time1Max;
			}
			break;
		case 2:
			time2Actual--;
			base.transform.Translate(Moove2 * Time.deltaTime);
			if (time2Actual <= 0)
			{
				state = 3;
				timePauseActual = timePauseMax;
			}
			break;
		case 1:
			time1Actual--;
			base.transform.Translate(Moove1 * Time.deltaTime);
			if (time1Actual <= 0)
			{
				state = 2;
				time2Actual = time2Max;
			}
			break;
		}
	}
}
