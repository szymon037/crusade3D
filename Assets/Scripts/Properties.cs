using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using UnityEngine;




public class Properties {

	public enum ActiveItem { // enum do aktywnych itemków
		None = -1,
		Test,
		HolyBagpipe,
		next1,
		next2,
		next3,
		next4,
		next5,
		next6,
		next7,
		next8,
		next9,
		next10,
		next11,
		next12,
		next13,
		next14,
		next15,
		next16,
		next17,
		next18,
		next19,
		next20
	}

	public int killCount 			= 0;

	private static Properties instance = null;
	public static Properties GetInstance() { // śliczny singletonik
		if (Properties.instance == null) {
			instance = new Properties();
		}
		return instance;
	}
	//TODO: dodać tymczasowe zmienne do trzymania wartości statystyk (na wypadek relikwii zmieniających ich wartości)
	public float damage 			= 0f;
	public float addedDamage		= 0f;
	public float health 			= 0f;
	public float faith 				= 0f;
	public float baseDmg			= 20f;
	public float maxHealth			= 100f;
	public float addedMaxHealth		= 0f;
	public float attackSpeed		= 2f;
	public float speed 				= 7.5f;
	public float addedSpeed 		= 0f;
	public float maxFaith			= 100f;
	public float addedMaxFaith		= 0f;
	public float faithConsumption	= 0f;//done
	public float baseAttackRange	= 1.5f;	//było 3f
	public float addedAttackRange	= 0f;
	public float attackRange 		= 0f;
	public int luck					= 0;//done
	public int addedLuck			= 0;
	public int extraLives 			= 0;//done
	public int money 				= 0;//done
	public int holyWater 			= 0;//done
	public int keys 				= 0;
	public int devilCounter 		= 0;//done
	public int protection 			= 0;//done
	public ActiveItem active        = (ActiveItem)(-1);//done
	

	public Dictionary<string, bool> flags 	= new Dictionary<string, bool>();//done //słownik z boolami żeby nie nasrać ich 50 tylko mieć ładną tablicę
	public GameObject activeItem 			= null; //nasz aktywny przedmiot //done
	
	public Properties() { //konstruktor ustawiający początkowe wartości
		flags["isRolling"] 			= false;
		flags["devilishItem"] 		= false;
		flags["ankh"] 				= false;
		flags["fireAtt"] 			= false;
		flags["isFlying"] 			= false;
		flags["bleed"] 				= false;
		flags["lifeLeech"] 			= false;
		flags["blessed"] 			= false;
		flags["ankhResurrection"] 	= false;
		flags["electricAtt"] 		= false;
		flags["poisonous"] 			= false;
		flags["damnation"] 			= false;
		flags["thirdEye"] 			= false;
		flags["crownOfThorns"] 		= false;
		flags["charging"] 			= false;
		flags["goatsSkull"]			= false;
		flags["greed"]				= false;
		flags["gatekeeper"]			= false;
		flags["hiddenMap"] 			= false;
		flags["isHit"]				= false;
		flags["isTransformed"]		= false;
		flags["confused"]			= false;
		flags["faithShield"]		= false;
		health 						= maxHealth;
		faith 						= maxFaith;
		damage 						= baseDmg;
		attackRange  				= baseAttackRange;
		/* tworzymy z itemEffects tablicę o wielkości enuma (index będzie odpowiadał metodzie danego przedmiotu) */
	}


	~Properties() { //destruktorek (SPRZONTAMY PO SOBJE HURR DURR)
		Clear();
	}



	void Clear() {
		flags.Clear();
		baseDmg			= 0;
		maxHealth		= 0;
		attackSpeed		= 0;
		damage 			= 0;
		health 			= 0;
		faith 			= 0;
		speed 			= 0;
		maxFaith 		= 0;			
		extraLives 		= 0; 
		money 			= 0; 	
		holyWater 		= 0; 
		keys 			= 0; 	
		devilCounter 	= 0;
		protection 		= 0; 
		luck 			= 0;
		baseAttackRange = 0;
		attackRange 	= 0;
		flags			= null;
		activeItem 		= null;
		active   		= (ActiveItem)(-1);
	}

//metoda do resetowania statystyk (np. gracz wybrał "Quick Restart")
	void Reset() {
		foreach (string key in flags.Keys.ToList()) {
			flags[key] = false;
		}
		maxHealth 			= 100f;
		maxFaith 			= 100f;
		damage 				= baseDmg;
		health 				= maxHealth;
		faith 				= maxFaith;
		speed 				= 2.5f;
		luck 				= 0;
		extraLives 			= 0;
		money 				= 0;
		active 				= ActiveItem.None;
		attackRange 		= baseAttackRange;
		attackSpeed 		= 2f;
		protection 			= 0;
		activeItem 			= null;
		keys 				= 0;
		holyWater 			= 0;
		devilCounter 		= 0;
		faithConsumption 	= 0f;
	}

	public static void ModifyHealth(int value) {
		instance.health += value;
		if (instance.health < 0) instance.health = 0;
		if (instance.health > instance.maxHealth) instance.health = instance.maxHealth;
	}

	public static void ModifyFaith(int value) {
		instance.faith += value;
		if (instance.faith < 0) instance.faith = 0;
		if (instance.faith > instance.maxFaith) instance.faith = instance.maxFaith;
	}

	public static void SetHealth(float value) {
		instance.health = value;
	}

	public static void SetFaith(float value) {
		instance.faith = value;
	}

	public static void SetMaxFaith(float value) {
		instance.maxFaith = value;
	}

	public static void SetMaxHealth(float value) {
		instance.maxHealth = value;
	}

	public static void ToggleFlag(string key, bool value) {
		instance.flags[key] = value;
	}

	public static void ModifyDamage(float multiplier) {
		instance.damage += (instance.baseDmg * multiplier);
	}	

	public static void ModifyMaxHealth(int value) {
		instance.addedMaxHealth += value;
	}

	public static void ModifyMaxFaith(int value) {
		instance.addedMaxFaith += value;
	}

	public static void SetActiveItem(GameObject other, int ID, float faithConsumption) {
		instance.activeItem = other;
		instance.active = (ActiveItem)ID;
		instance.faithConsumption = faithConsumption;
	}

	public static void ModifyLuck(int value) {
		instance.luck += value;
	}

	public static void ModifyMoneyCount(int amount) {
		instance.money += amount;
	}

	public static void ModifyHolyWaterCount(int amount) {
		instance.holyWater += amount;
	}

	public static void ModifyProtection(int value) {
		instance.protection += value;
	}

	public static void IncreaseDevilItemsCounter() {
		++instance.devilCounter;
	}

	public static void DecreaseDevilItemsCounter() {
		--instance.devilCounter;
	}

	public static void ModifyExtraLives(int amount) {
		instance.extraLives += amount; 
	}

	public static void ModifySpeed(float value) {
		instance.addedSpeed += value;
	}

	public static void ModifyAttackSpeed(float value) {
		instance.attackSpeed += value;
	}

	public static void ModifyKeyCount(int amount) {
		instance.keys += amount;
	}

	public static void ModifyAttackRange(int value) {
		instance.addedAttackRange += value;
	}

	public static void SetAttackSpeed(float value) {
		instance.attackSpeed = value;
		if (instance.attackSpeed < 0.5f) instance.attackSpeed = 0.5f;
	}

	public static void SetSpeed(float value) {
		instance.speed = value;
	}

	public static void IncreaseKillCount() {
		++instance.killCount;
	}
}
