using UnityEngine;
using System.Collections;

public class Combinations : MonoBehaviour {

    [HideInInspector]
	public string coinCombination, heartCombination, bootsCombination;
	
    [HideInInspector]
	public string firstNoteComb, secondNoteComb, thirdNoteComb, fourthNoteComb;
	
	//we can add more notes if we need it for longer combinations

	int Check;
    
	//MUSIC NOTES ENGLISH
	//c --> DO --> Black
	//d --> RE --> Green
	//e --> MI --> Yellow
	//f --> FA --> blue
	//g --> SOL --> White
	//a --> LA --> Purple
	//b --> SI --> Red


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string SetRandomCoinCombination(int combinationSize){
			coinCombination = ""; //Empties the variable
			for(int i = 0; i <= combinationSize; i++){
				int Rnd = Random.Range(0, 7);
				switch(Rnd){
					case 0:
						coinCombination = coinCombination + "C";
						break;
					case 1:
						coinCombination = coinCombination + "D";
						break;
					case 2:
						coinCombination = coinCombination + "E";
						break;
					case 3:
						coinCombination = coinCombination + "F";
						break;
					case 4:
						coinCombination = coinCombination + "G";
						break;
					case 5:
						coinCombination = coinCombination + "A";
						break;
					case 6:
						coinCombination = coinCombination + "B";
						break;
					
					}
			}
		return coinCombination;
				
	}
	
	public string SetSpecialCombination(){
		string Special = "";
		//SPECIAL COMBINATIONS
		//Heart --> BBBB
		//Boots --> CDEFGAB
		
		//Implement here some AI to check which one to do
		int Rnd = Random.Range(0, 2);
		switch(Rnd){
			case 0: //Heart
				Special = "BBBB";
			break;
			case 1:
				Special = "CDEF";
			break;
		}
		
		
		return Special;
	}

	public int CheckHowMany(string CombinationName, string ColourToCheck, int CombSize){
		Check = 0;
		string colour;
		for (int i = 0; i < CombSize; i++) {
			colour = CombinationName.Substring(i, 1);
			if(colour == ColourToCheck){
				Check += 1;
			}
			colour = "";
		}
		return Check;
	}

	public void CheckEachNote(string CombinationName, int CombSize){

        for (int i = 0; i <= CombSize; i++)
        {
            switch(i){
                case 0:
                    firstNoteComb = CombinationName.Substring(i, 1);
                    break;
                case 1:
                    secondNoteComb = CombinationName.Substring(i, 1);
                    break;
                case 2:
                    thirdNoteComb = CombinationName.Substring(i, 1);
                    break;
                case 3:
                    fourthNoteComb = CombinationName.Substring(i, 1);
                    break;                      
            }
            //Debug.Log ("First: " + firstNoteComb + " Second: " + secondNoteComb + " Third: " + thirdNoteComb + " Fourth: " + fourthNoteComb);
        }
	}


}
