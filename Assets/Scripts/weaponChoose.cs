using UnityEngine;

public class weaponChoose : MonoBehaviour
{
	private GameManager SkinChoose;

	public bool Player1;

	public int Choose1;

	public int Choose2;

	[Header("Armes")]
	public GameObject Sword1;

	public GameObject Sword2;

	public GameObject Yoyo1;

	public GameObject Yoyo2;

	public GameObject Marteau1;

	public GameObject Marteau11;

	public GameObject Marteau2;

	public GameObject Marteau22;

	public GameObject Grappin1;

	public GameObject Grappin11;

	public GameObject Grappin2;

	public GameObject Grappin22;

	public GameObject Shoot1;

	public GameObject Shoot2;

	public GameObject Baguette1;

	public GameObject Baguette11;

	public GameObject Baguette2;

	public GameObject Baguette22;

	public GameObject Arc1;

	public GameObject Arc2;

	public GameObject Boot1;

	public GameObject Boot11;

	public GameObject Boot2;

	public GameObject Boot22;

	public GameObject Punch1;

	public GameObject Punch11;

	public GameObject Punch2;

	public GameObject Punch22;

	public GameObject IceCream1;

	public GameObject IceCream2;

	public GameObject Chaussure1;

	public GameObject Chaussure11;

	public GameObject Chaussure2;

	public GameObject Chaussure22;

	public GameObject Knife1;

	public GameObject Knife2;

	public GameObject Guitare1;

	public GameObject Guitare2;

	public GameObject Katana1;

	public GameObject Katana2;

	public GameObject Bomb1;

	public GameObject Bomb2;

	public GameObject PortalGun1;

	public GameObject PortalGun2;

	public GameObject Lance1;

	public GameObject Lance2;

	public GameObject Faux1;

	public GameObject Faux2;

	public GameObject Hache1;

	public GameObject Hache2;

	public GameObject Scie1;

	public GameObject Scie11;

	public GameObject Scie2;

	public GameObject Scie22;

	public GameObject Sniper1;

	public GameObject Sniper2;

	public GameObject Bouclier1;

	public GameObject Bouclier2;

	public GameObject Gauntlet1;

	public GameObject Gauntlet2;

	public GameObject Spear1;

	public GameObject Spear11;

	public GameObject Spear2;

	public GameObject Spear22;

	public GameObject Lightsaber1;

	public GameObject Lightsaber11;

	public GameObject Lightsaber2;

	public GameObject Lightsaber22;

	public GameObject Bazouka1;

	public GameObject Bazouka2;

	public GameObject Pioche1;

	public GameObject Pioche11;

	public GameObject Pioche2;

	public GameObject Pioche22;

	public GameObject Shuriken1;

	public GameObject Shuriken2;

	public GameObject Pinceau1;

	public GameObject Pinceau11;

	public GameObject Pinceau2;

	public GameObject Pinceau22;

	public GameObject IronHand1;

	public GameObject IronHand2;

	[Header("Projectiles")]
	public GameObject[] FlecheBLeu;

	public GameObject[] FlecheRouge;

	public GameObject[] BombBleu;

	public GameObject[] BombRouge;

	public GameObject[] PiocheBleu;

	public GameObject[] PiocheRouge;

	public GameObject[] PortalBleu;

	public GameObject[] PortalRouge;

	public GameObject[] LightSaberBleu;

	public GameObject[] LightSaberRouge;

	public GameObject[] EncreBleu;

	public GameObject[] EncreRouge;

	private void Start()
	{
		SkinChoose = GameObject.Find("GameManager").GetComponent<GameManager>();
		Choose1 = 31;
		Choose2 = 31;
		if (SkinChoose.weaponB == 0)
		{
			Choose1 = UnityEngine.Random.Range(0, 30);
		}
		if (SkinChoose.weaponR == 0)
		{
			Choose2 = UnityEngine.Random.Range(0, 30);
			if (SkinChoose.weaponB == 0 && SkinChoose.weaponR == 0 && SkinChoose.RandomSameWeapon)
			{
				Choose2 = Choose1;
			}
		}
		SkinBleu[] array = Resources.FindObjectsOfTypeAll<SkinBleu>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].num == SkinChoose.AccesorieB)
			{
				array[i].gameObject.SetActive(value: true);
			}
		}
		SkinRouge[] array2 = Resources.FindObjectsOfTypeAll<SkinRouge>();
		for (int j = 0; j < array2.Length; j++)
		{
			if (array2[j].num == SkinChoose.AccesorieR)
			{
				array2[j].gameObject.SetActive(value: true);
			}
		}
		if (SkinChoose.weaponB == 1 || Choose1 == 0)
		{
			Sword1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 2 || Choose1 == 1)
		{
			Marteau11.SetActive(value: true);
			Marteau1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 3 || Choose1 == 2)
		{
			Grappin1.SetActive(value: true);
			Grappin11.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 4 || Choose1 == 3)
		{
			Shoot1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 5 || Choose1 == 4)
		{
			Baguette11.SetActive(value: true);
			Baguette1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 6 || Choose1 == 5)
		{
			Yoyo1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 7 || Choose1 == 6)
		{
			Arc1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 8 || Choose1 == 7)
		{
			Boot1.SetActive(value: true);
			Boot11.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 9 || Choose1 == 8)
		{
			Punch1.SetActive(value: true);
			Punch11.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 10 || Choose1 == 9)
		{
			IceCream1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 11 || Choose1 == 10)
		{
			Chaussure1.SetActive(value: true);
			Chaussure11.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 12 || Choose1 == 11)
		{
			Knife1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 13 || Choose1 == 12)
		{
			Guitare1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 14 || Choose1 == 13)
		{
			Katana1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 15 || Choose1 == 14)
		{
			Bomb1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 16 || Choose1 == 15)
		{
			PortalGun1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 17 || Choose1 == 16)
		{
			Faux1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 18 || Choose1 == 17)
		{
			Scie1.SetActive(value: true);
			Scie11.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 19 || Choose1 == 18)
		{
			Hache1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 20 || Choose1 == 19)
		{
			Lance1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 21 || Choose1 == 20)
		{
			Sniper1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 22 || Choose1 == 21)
		{
			Bouclier1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 23 || Choose1 == 22)
		{
			Gauntlet1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 24 || Choose1 == 23)
		{
			Spear11.SetActive(value: true);
			Spear1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 25 || Choose1 == 24)
		{
			Lightsaber1.SetActive(value: true);
			Lightsaber11.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 26 || Choose1 == 25)
		{
			Bazouka1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 27 || Choose1 == 26)
		{
			Pioche11.SetActive(value: true);
			Pioche1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 28 || Choose1 == 27)
		{
			Shuriken1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 29 || Choose1 == 28)
		{
			IronHand1.SetActive(value: true);
		}
		if (SkinChoose.weaponB == 30 || Choose1 == 29)
		{
			Pinceau11.SetActive(value: true);
			Pinceau1.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 1 || Choose2 == 0)
		{
			Sword2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 2 || Choose2 == 1)
		{
			Marteau22.SetActive(value: true);
			Marteau2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 3 || Choose2 == 2)
		{
			Grappin2.SetActive(value: true);
			Grappin22.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 4 || Choose2 == 3)
		{
			Shoot2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 5 || Choose2 == 4)
		{
			Baguette22.SetActive(value: true);
			Baguette2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 6 || Choose2 == 5)
		{
			Yoyo2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 7 || Choose2 == 6)
		{
			Arc2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 8 || Choose2 == 7)
		{
			Boot2.SetActive(value: true);
			Boot22.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 9 || Choose2 == 8)
		{
			Punch22.SetActive(value: true);
			Punch2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 10 || Choose2 == 9)
		{
			IceCream2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 11 || Choose2 == 10)
		{
			Chaussure2.SetActive(value: true);
			Chaussure22.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 12 || Choose2 == 11)
		{
			Knife2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 13 || Choose2 == 12)
		{
			Guitare2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 14 || Choose2 == 13)
		{
			Katana2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 15 || Choose2 == 14)
		{
			Bomb2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 16 || Choose2 == 15)
		{
			PortalGun2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 17 || Choose2 == 16)
		{
			Faux2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 18 || Choose2 == 17)
		{
			Scie2.SetActive(value: true);
			Scie22.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 19 || Choose2 == 18)
		{
			Hache2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 20 || Choose2 == 19)
		{
			Lance2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 21 || Choose2 == 20)
		{
			Sniper2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 22 || Choose2 == 21)
		{
			Bouclier2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 23 || Choose2 == 22)
		{
			Gauntlet2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 24 || Choose2 == 23)
		{
			Spear22.SetActive(value: true);
			Spear2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 25 || Choose2 == 24)
		{
			Lightsaber2.SetActive(value: true);
			Lightsaber22.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 26 || Choose2 == 25)
		{
			Bazouka2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 27 || Choose2 == 26)
		{
			Pioche22.SetActive(value: true);
			Pioche2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 28 || Choose2 == 27)
		{
			Shuriken2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 29 || Choose2 == 28)
		{
			IronHand2.SetActive(value: true);
		}
		if (SkinChoose.weaponR == 30 || Choose2 == 29)
		{
			Pinceau22.SetActive(value: true);
			Pinceau2.SetActive(value: true);
		}
		Effacable[] array3 = Resources.FindObjectsOfTypeAll<Effacable>();
		for (int k = 0; k < array3.Length; k++)
		{
			if (!array3[k].gameObject.activeInHierarchy)
			{
				UnityEngine.Object.Destroy(array3[k].gameObject);
			}
		}
		if (SkinChoose.weaponB != 7 && Choose1 != 6)
		{
			for (int l = 0; l < FlecheBLeu.Length; l++)
			{
				UnityEngine.Object.Destroy(FlecheBLeu[l].gameObject);
			}
		}
		if (SkinChoose.weaponR != 7 && Choose2 != 6)
		{
			for (int m = 0; m < FlecheRouge.Length; m++)
			{
				UnityEngine.Object.Destroy(FlecheRouge[m].gameObject);
			}
		}
		if (SkinChoose.weaponB != 15 && Choose1 != 14)
		{
			for (int n = 0; n < BombBleu.Length; n++)
			{
				UnityEngine.Object.Destroy(BombBleu[n].gameObject);
			}
		}
		if (SkinChoose.weaponR != 15 && Choose2 != 14)
		{
			for (int num = 0; num < BombRouge.Length; num++)
			{
				UnityEngine.Object.Destroy(BombRouge[num].gameObject);
			}
		}
		if (SkinChoose.weaponB != 27 && Choose1 != 26)
		{
			for (int num2 = 0; num2 < PiocheBleu.Length; num2++)
			{
				UnityEngine.Object.Destroy(PiocheBleu[num2].gameObject);
			}
		}
		if (SkinChoose.weaponR != 27 && Choose2 != 26)
		{
			for (int num3 = 0; num3 < PiocheRouge.Length; num3++)
			{
				UnityEngine.Object.Destroy(PiocheRouge[num3].gameObject);
			}
		}
		if (SkinChoose.weaponB != 16 && Choose1 != 15)
		{
			for (int num4 = 0; num4 < PortalBleu.Length; num4++)
			{
				UnityEngine.Object.Destroy(PortalBleu[num4].gameObject);
			}
		}
		if (SkinChoose.weaponR != 16 && Choose2 != 15)
		{
			for (int num5 = 0; num5 < PortalRouge.Length; num5++)
			{
				UnityEngine.Object.Destroy(PortalRouge[num5].gameObject);
			}
		}
		if (SkinChoose.weaponB != 25 && Choose1 != 24)
		{
			for (int num6 = 0; num6 < LightSaberBleu.Length; num6++)
			{
				UnityEngine.Object.Destroy(LightSaberBleu[num6].gameObject);
			}
		}
		if (SkinChoose.weaponR != 25 && Choose2 != 24)
		{
			for (int num7 = 0; num7 < LightSaberRouge.Length; num7++)
			{
				UnityEngine.Object.Destroy(LightSaberRouge[num7].gameObject);
			}
		}
		if (SkinChoose.weaponB != 30 && Choose1 != 29)
		{
			for (int num8 = 0; num8 < EncreBleu.Length; num8++)
			{
				UnityEngine.Object.Destroy(EncreBleu[num8].gameObject);
			}
		}
		if (SkinChoose.weaponR != 30 && Choose2 != 29)
		{
			for (int num9 = 0; num9 < EncreRouge.Length; num9++)
			{
				UnityEngine.Object.Destroy(EncreRouge[num9].gameObject);
			}
		}
	}
}
