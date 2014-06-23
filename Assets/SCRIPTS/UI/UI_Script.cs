using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {

		public Texture LifePixel; //Texture to draw life bar
		public Texture LifeFrame; //Frame to draw 
		public Texture TimerFrame; //Timer frame
		public Texture StaveFrame;
        public Texture ScoreTexture;
        public Texture FacebookTexture;
        public Texture FacebookClickedTexture;
        public Texture TweeterTexture;
        public Texture TweeterClickedTexture;
        public Texture RestartTexture;
        public Texture RestartTextureClicked;
        public Texture mainMenu;
        public Texture NextLevel;
        
           
		public GUIStyle TimerStyle; //Style of the Timer
		public GUIStyle CoinStyle; //Style of the Coin text
		public GUIStyle MoneyStyle; //Style of the Money text
		public GUIStyle LifeTextStyle;	//Style of the Life text

        public static bool ShowFBClicked;
        public static bool ShowTWClicked;
        public static bool ShowRestartCliked;

		//Textures of the notes
		public Texture blackNoteTexture_NPU;
		public Texture blackNoteTexture_PU;
		public Texture greenNoteTexture_NPU;
		public Texture greenNoteTexture_PU;
		public Texture yellowNoteTexture_NPU;
		public Texture yellowNoteTexture_PU;
		public Texture blueNoteTexture_NPU;
		public Texture blueNoteTexture_PU;
		public Texture whiteNoteTexture_NPU;
		public Texture whiteNoteTexture_PU;
		public Texture purpleNoteTexture_NPU;
		public Texture purpleNoteTexture_PU;
		public Texture redNoteTexture_NPU;
		public Texture redNoteTexture_PU;

        public Texture mistakeComb_NPU;
        public Texture mistakeComb_PU;

        public Texture heartHealth;
        
		Combinations combScript; //Combinations script	

        public Texture emptyStar;
        public Texture fullStar;

		//MUSIC NOTES ENGLISH
		//c --> DO --> Black
		//d --> RE --> Green
		//e --> MI --> Yellow
		//f --> FA --> blue
		//g --> SOL --> White
		//a --> LA --> Purple
		//b --> SI --> Red

		public Texture number_0;
		public Texture number_1;
		public Texture number_2;
		public Texture number_3;
		public Texture number_4;
		public Texture number_5;
		public Texture number_6;
		public Texture number_7;
		public Texture number_8;
		public Texture number_9;
	
	
		public Texture letter_A;
		public Texture letter_B;
		public Texture letter_C;
		public Texture letter_D;
		public Texture letter_E;
		public Texture letter_F;
		public Texture letter_G;
		public Texture letter_H;
		public Texture letter_I;
		public Texture letter_J;
		public Texture letter_K;
		public Texture letter_L;
		public Texture letter_M;
		public Texture letter_N;
		public Texture letter_O;
		public Texture letter_P;
		public Texture letter_Q;
		public Texture letter_R;
		public Texture letter_S;
		public Texture letter_T;
		public Texture letter_U;
		public Texture letter_V;
		public Texture letter_W;
		public Texture letter_X;
		public Texture letter_Y;
		public Texture letter_Z;

        public float fittingScreenGapValue = 0.02f;

        public bool showScore = false;

        Transform thisTransform;

        //Create Margins.
        Vector2 minimumMargin;
            
        SpawnTiles spawnScript;
        Player_Script playerScript;
        Score scoreScript;

        ReallocatePositionAndSizeGUI readjustGUIscript;

        Animator startAnimator;
        Animator finishAnimator;

        float originalWidth = 854;// Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 2056.
        float originalHeight = 480;//Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 1536.

		void Start () {
            GUI.enabled = true;
            showScore = false;
			combScript = (Combinations)GameObject.FindGameObjectWithTag ("Grid").GetComponent<Combinations> ();
            spawnScript = (SpawnTiles)GameObject.FindGameObjectWithTag("Grid").GetComponent<SpawnTiles>();
            playerScript = (Player_Script)GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
            scoreScript = (Score)GameObject.FindGameObjectWithTag("Grid").GetComponent<Score>();

            readjustGUIscript = (ReallocatePositionAndSizeGUI)Camera.main.transform.GetComponent<ReallocatePositionAndSizeGUI>();

            minimumMargin = new Vector2(Screen.width * fittingScreenGapValue, Screen.height * fittingScreenGapValue);

            thisTransform = transform;

            startAnimator = thisTransform.FindChild("ScreenAnimation_StartFinish").FindChild("LevelStart").GetComponent<Animator>();
            finishAnimator = thisTransform.FindChild("ScreenAnimation_StartFinish").FindChild("LevelFinish").GetComponent<Animator>();


           
			}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown(KeyCode.F1)){
                Application.LoadLevel(1);
            }
		}


        void OnGUI()
        {
            

            if (Player_Script.Player_Current_Life == playerScript.Player_Initial_Life)
            {
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(95, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(95, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(165, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(165, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(240, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(240, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
            }
            else if (Player_Script.Player_Current_Life == (playerScript.Player_Initial_Life - (playerScript.Player_Initial_Life / 4)))
            {
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(95, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(95, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(165, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(165, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
            }
            else if (Player_Script.Player_Current_Life == (playerScript.Player_Initial_Life / 2))
            {
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).y,
                   readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(95, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(95, 12, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);
            }
            else if (Player_Script.Player_Current_Life == (playerScript.Player_Initial_Life - (playerScript.Player_Initial_Life / 4) * 3))
            {
                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(20, 12, originalWidth, originalHeight).y,
                   readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(70, 70, originalWidth, originalHeight).y), heartHealth, ScaleMode.ScaleToFit, true, 0.0F);

            }

            string text;

            text = "BEST COMBINATION: " + PlayerPrefs.GetInt("HighComb");
            //GUI.Label(new Rect(Screen.width / 2 - 560, 580, 220, 20), text, MoneyStyle);

            text = "BEST COIN: " + PlayerPrefs.GetInt("HighCoins");
            //GUI.Label(new Rect(Screen.width / 2 - 560, 60, 220, 20), text, MoneyStyle);

            text = "BEST MONEY: " + PlayerPrefs.GetInt("HighMoney");
            //GUI.Label(new Rect(Screen.width / 2 - 560, 640, 220, 20), text, MoneyStyle);

            if (Game_Manager.levelFinished == false)
            {


                switch (combScript.firstNoteComb)
                {
                    case "C":
                        if (spawnScript.firstPickedUp == false) //I was using the Objects Hit Script variable before
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                        readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "D":
                        if (spawnScript.firstPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "E":
                        if (spawnScript.firstPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "F":
                        if (spawnScript.firstPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "G":
                        if (spawnScript.firstPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "A":
                        if (spawnScript.firstPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "B":
                        if (spawnScript.firstPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.firstFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(620, 0, originalWidth, originalHeight).y,
                                    readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                }

                switch (combScript.secondNoteComb)
                {
                    case "C":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "D":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "E":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "F":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "G":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "A":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "B":
                        if (spawnScript.secondPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.secondFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(669, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                }

                switch (combScript.thirdNoteComb)
                {
                    case "C":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            //if (SpawnTiles.fuckedUpSequence == true)
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "D":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "E":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "F":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "G":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "A":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "B":
                        if (spawnScript.thirdPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.thirdFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(718, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                }

                switch (combScript.fourthNoteComb)
                {
                    case "C":
                        if (spawnScript.fourthPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blackNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "D":
                        if (spawnScript.fourthPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), greenNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "E":
                        if (spawnScript.fourthPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), yellowNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "F":
                        if (spawnScript.fourthPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), blueNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "G":
                        if (spawnScript.fourthPickedUp == false)
                        {

                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), whiteNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "A":
                        if (spawnScript.fourthPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), purpleNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                    case "B":
                        if (spawnScript.fourthPickedUp == false)
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_NPU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        else
                        {
                            GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), redNoteTexture_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            if (spawnScript.fourthFuckedUp == true)
                            {
                                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUIPosition(767, 0, originalWidth, originalHeight).y,
                                readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIscript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), mistakeComb_PU, ScaleMode.ScaleToFit, true, 0.0F);
                            }
                        }
                        break;
                }
            }       

            GUI.backgroundColor = Color.clear;

            //We need to set up a next and restart screen

            if (showScore == true)
            {
                Vector2 leftUpAnchorScore = new Vector2(readjustGUIscript.ReadjustGUIPosition(180, 50, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(180, 50, originalWidth, originalHeight).y);

                /*GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(100, 5, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(100, 5, originalWidth, originalHeight).y, 
                    readjustGUIscript.ReadjustGUISize(661, 472, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(661, 472, originalWidth, originalHeight).y), ScoreTexture, ScaleMode.ScaleAndCrop, true, 0.0F);*/

                GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(100, 5, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(100, 5, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(661, 472, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(661, 472, originalWidth, originalHeight).y), ScoreTexture, ScaleMode.StretchToFill, true, 0.0F);

                if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(130, 350, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(130, 350, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).y), TweeterTexture))
                {
                    ShowTWClicked = true;
                }
                if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(230, 350, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(230, 350, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).y), FacebookTexture))
                {
                    ShowFBClicked = true;
                }

                if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(430, 350, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(430, 350, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).y), mainMenu))
                {
                    Invoke("GoMainMenu", 1.5f);
                    //Invoke("LoadNextLevel", 1.5f);
                }
                if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(530, 350, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(530, 350, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).y), RestartTexture))
                {
                    Invoke("RestartGame", 1.5f);
                    //Invoke("LoadNextLevel", 1.5f);
                }
                if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(630, 350, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(630, 350, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(104, 104, originalWidth, originalHeight).y), NextLevel))
                {
                    //Invoke("RestartGame", 1.5f);
                    Invoke("LoadNextLevel", 1.5f);
                }


                //Showing stars
                scoreScript.SetStars();
                scoreScript.SetScore();
                //Debug.Log(scoreScript.GetScore());

                //Debug.Log("Three stars: " + Score.threeStars + " Two Stars: " + Score.twoStars + " One Star: " + Score.oneStar);

                if (Score.oneStar == true)
                {
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(630, 350, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(200, 350, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), fullStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), emptyStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), emptyStar, ScaleMode.ScaleToFit, true, 0.0F);
                }
                else
                {
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(280, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(280, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), emptyStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), emptyStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), emptyStar, ScaleMode.ScaleToFit, true, 0.0F);
                }
                if (Score.threeStars == true)
                {
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(280, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(280, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), fullStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), fullStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), fullStar, ScaleMode.ScaleToFit, true, 0.0F);
                }
                if (Score.twoStars == true)
                {
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(280, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(280, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), fullStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(390, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), fullStar, ScaleMode.ScaleToFit, true, 0.0F);
                    GUI.DrawTexture(new Rect(readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUIPosition(500, 75, originalWidth, originalHeight).y,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).x,
                    readjustGUIscript.ReadjustGUISize(113, 109, originalWidth, originalHeight).y), emptyStar, ScaleMode.ScaleToFit, true, 0.0F);
                }
                
            }


                //Close and return ne Matrix value.
                //GUI.matrix = svMatrix;
            }
        
            
            
              

        void GoMainMenu()
        {
            Objects_Hit_Player.ResetPicked();
            Application.LoadLevel("LEVEL_MAP");
        }

        void RestartGame()
        {                    
            Objects_Hit_Player.ResetPicked();
            Game_Manager.levelFinished = false;
            Application.LoadLevel(Game_Manager.currentLevel);    
        }

        void LoadNextLevel()
        {
            Score.comboCounter = 0;
            Game_Manager.levelFinished = false;
            Game_Manager.LoadNextLevel();
        }

        public void PlayStartAnimation()
        {
            startAnimator.SetTrigger("PlayAnimation");
        }

        public void PlayFinishAnimation()
        {
            finishAnimator.SetTrigger("PlayAnimation");
        }
  }
      
           


