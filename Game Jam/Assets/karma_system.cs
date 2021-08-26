using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class karma_system : MonoBehaviour
{
    private List<string> city = new List<string>{"Yuval Bobax", "Kilorry Hilton", "Hitoley Kizabar","Sirton","Moogaz","WhichLand","Dediabab", "Zamidi","kiloof","Fizit","RudiCity","Hnana","Cishlon","MastikLand", "Soragi","Jay Ms","Shrmooka","Moist Mangeles", "Shuman Ravuy", "Dgdfgvf", "Lost Mangeles", "yaira", "Yonashlaim", "Hontoza", "Kizabanda", "Sigaone", "TheRot", "Ret Fix", "Man giego", "Mondon", "Kong Hong", "Moronto", "Mahir", "Kash", "Mishgal", "Pipika", "Shalikda", "Yaki&Bob", "TelOfita", "Mosko", "Shaon", "Dilra&Kofiko","Dardask", "xanthocarpous", "iparona", "nadavile", "YonaDan", "Bengadan", "KongaDonga","RonitShulman", "Zymology", "Meavrerya", "Hodika","SartanHalashon","Sotikia","Ratoov","Banot Bakolnoa", "koosit","Drafty","Typo", "Teoona","zera","lehaki", "kvardada", "ingera", "izhak","pastak","ribooarba","Dana","Haroozi","Skotla","Boomi","AoodiFine", "zipori","Manoola","ChahlaLand","simpa","kakesh","koosiko", "Harglaimshelserge", "Flotz & Flitz"} ;
    public Text txt1;
    public Text city1name_txt;
    public Text city2name_txt;
    public Text txt2;
    public Slider population;
    public Slider Industry;
    public Slider money;
    public Slider culture;
    public Slider education;
    public Slider food_production;
    public Slider torisum;
    public GameObject points;
    public Text points_text;
    // Button right
    public Slider population2;
    public Slider Industry2;    
    public Slider money2;
    public Slider culture2;
    public Slider education2;
    public Slider food_production2;
    public Slider torisum2;
    private float timeLeft = 7;
    public Slider population_now;
    public Slider industry_now;
    public Slider money_now;
    public Slider culture_now;
    public Slider education_now;
    public Slider food_production_now;
    public Slider torisum_now;
    public Text population_text1;
    public Text industry1_text;
    public Text money1_text;
    public Text culture1_text;
    public Text education1_text;
    public Text food1_text;
    public Text torisum1_text;
    public Text population_text2;
    public Text industry2_text;
    public Text money2_text;
    public Text culture2_text;
    public Text education2_text;
    public Text food2_text;
    public Text torisum2_text;
    public Text population_text_country;
    public Text industry_text_country;
    public Text money_text_country;
    public Text culture_text_now;
    public Text education_text_now;
    public Text food_text_now;
    public Text torisum_text_now;
    private int pointsssss = 0;
    public Text countownText;

    private bool startTimer = false;

    private int number_days = 0;
    
    public GameObject transitionScreen;

    public Text amountOfDaysText;
    public Slider food_plus;
    public Slider culture_plus;
    public Slider education_plus;
    public Slider torisum_plus;
    public Slider money_plus;
    public Slider industry_plus;
    public Slider population_plus;
    

    void Start()
    {

        for (int i = 0; i < get_now_plus_sliders("plus").Length;i++){
            get_now_plus_sliders("plus")[i].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0,255,0);
        }

        Cursor.visible = false;
        generateNewCityKarma();

    }


    public void reduceRightBtn(Slider[] now_Sliders, Slider[] right_sliders){
        for(int i = 0;i<now_Sliders.Length;i++){
            if (right_sliders[i].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color == new Color(0,255,0)){
                now_Sliders[i].value += right_sliders[i].value/2;
            }
            else{
                if(now_Sliders[i].value <= 0){
                    now_Sliders[i].value = 0;
                }
                else{
                    now_Sliders[i].value -= right_sliders[i].value/2;
                }
                
            }
        }
    }
    public void RightBtn(){
        reduceLeftBtn(get_now_plus_sliders("now"),get_slider_reduce("left"));
        generateNewCityKarma();
        pointsssss++;
        
    }
    public void reduceLeftBtn(Slider[] now_Sliders, Slider[] left_sliders){
        for(int i = 0;i<now_Sliders.Length;i++){
            if (left_sliders[i].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color == new Color(0,255,0)){
                now_Sliders[i].value += left_sliders[i].value/2;
            }
            else{now_Sliders[i].value -= left_sliders[i].value/2;}
        }
    }

    public void LeftBtn(){
        
        reduceRightBtn( get_now_plus_sliders("now"),get_slider_reduce("right"));
        generateNewCityKarma();
        pointsssss ++;
    }
    private void changeSliderColor(Slider[] sliders){
        for (int i = 0; i < sliders.Length;i++){
            sliders[i].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0,0,0);
        }
        
        int rand_left = UnityEngine.Random.Range(0, get_slider_reduce("left").Length-1);
        int rand_right = UnityEngine.Random.Range(0, get_slider_reduce("right").Length-1);

        get_slider_reduce("left")[rand_left].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0,255,0);
        get_slider_reduce("left")[rand_left].value = UnityEngine.Random.Range(0.0f, 0.2f);
        
        get_slider_reduce("right")[rand_right].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(0,255,0);
        get_slider_reduce("left")[rand_right].value = UnityEngine.Random.Range(0.0f, 0.15f);
        
        for (int i = 0; i < sliders.Length;i++){
            if(sliders[i].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color != new Color(0,255,0) ){
                sliders[i].gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color(255,0,0);
            }
        }
    }
    
    IEnumerator cool_trans_day(Slider[] plus_Sliders){
        int days = number_days/6;
        float plus_number;
        transitionScreen.SetActive(true);
        for (int i =0; i< plus_Sliders.Length;i++){
            plus_number = UnityEngine.Random.Range(0.0f,0.2f);
            plus_Sliders[i].value = plus_number;
            get_now_plus_sliders("now")[i].value += plus_number;
        }
        
        
        
        Debug.Log("madick1");        
        amountOfDaysText.text = "You Survived: " + days.ToString() + " Days!";
        yield return new WaitForSeconds(7);
        transitionScreen.SetActive(false);
        generateNewCityKarma();

    }

    public void lost_screen(string why){
        points.SetActive(true);
        points_text.text = why;
    }

    public void generateNewCityKarma()
    {
        Slider[] sliders = {population,population2,food_production,food_production2,Industry,Industry2,culture,culture2,torisum,torisum2,education, education2,money,money2};
        
        number_days++;
        Debug.Log(number_days);
        if(number_days % 6 == 0){
            StartCoroutine(cool_trans_day(get_now_plus_sliders("plus")));
        }
        
        if (city.Count < 2)
        {
            lost_screen("You Won!");
        }
        if (food_production_now.value == 0 && industry_now.value == 0 && money_now.value == 0 && population_now.value == 0 && culture_now.value == 0 && torisum_now.value == 0 && education_now.value == 0){
            lost_screen("All Your resources are GONE.\nYou Survived " + number_days/6 + " days!");
        }
        else if (population_now.value == 0){
            lost_screen("All Your People are DEAD! \nYou Survived " + number_days/6 + " days!");
        }
        else{
            int rnd_value = UnityEngine.Random.Range(0,city.Count);
            txt1.text = city[rnd_value];
            city.Remove(city[rnd_value]);

            rnd_value = UnityEngine.Random.Range(0,city.Count);

            txt2.text = city[rnd_value];
            city.Remove(city[rnd_value]);
            
            population.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            food_production.value =  (float)UnityEngine.Random.Range(0.0f,0.50f);
            Industry.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            culture.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            torisum.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            education.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            money.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            population2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            food_production2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            Industry2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            culture2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            torisum2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            education2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            money2.value = (float)UnityEngine.Random.Range(0.0f,0.50f);
            changeSliderColor(sliders);
         
        }
        ColorMixer();
        city1name_txt.text = "Save " + txt1.text;
        city2name_txt.text = "Save " + txt2.text;
        timeLeft = 7;
        startTimer = true;
        
    }
    public Slider[] get_slider_reduce(string What_func){
        Slider[] right_sliders = {population2,food_production2,Industry2,culture2,torisum2,education2,money2};
        Slider[] left_sliders = {population,food_production,Industry,culture,torisum,education,money};
        if (What_func == "left"){
            return left_sliders;
        }
        else{
            return right_sliders;
        }
    }
    public Slider[] get_now_plus_sliders(string What_func){
        Slider[] plus_Sliders = {population_plus, food_plus, industry_plus, culture_plus,torisum_plus,education_plus,money_plus};
        Slider[] now_Sliders = {population_now, food_production_now, industry_now, culture_now, torisum_now, education_now, money_now};
        if (What_func == "now"){
            return now_Sliders;
        }
        else{
            return plus_Sliders;
        }
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            LeftBtn();
        }
        if(Input.GetMouseButtonDown(1)){
            RightBtn();
        }
        if (startTimer){
            timeLeft -= Time.deltaTime;
            countownText.text = timeLeft.ToString();
            if ( timeLeft < 0 ){
                Slider[] sliders = {population,population2,food_production,food_production2,Industry,Industry2,culture,culture2,torisum,torisum2,education, education2,money,money2};
                for(int i =0; i<sliders.Length-1;i++){
                    get_now_plus_sliders("now")[i].value -= get_slider_reduce("left")[i].value;
                    get_now_plus_sliders("now")[i].value -= get_slider_reduce("right")[i].value;
                }
                timeLeft = 7;
                startTimer = false;
                generateNewCityKarma();
            }
        }


    }
    private void ColorMixer(){
        if(population.value < 0.25f){
            population_text1.color = Color.green;
        }
        if(population2.value < 0.25f){
            population_text2.color = Color.green;
        }
        if(population_now.value < 0.25f){
            population_text_country.color = Color.red;
        }
        if(education.value < 0.25f){
            education1_text.color = Color.green;
        }
        if(education2.value < 0.25f){
            education2_text.color = Color.green;
        }
        if(education_now.value < 0.25f){
            education_text_now.color = Color.red;
        }
        if(food_production.value < 0.25f){
            food1_text.color = Color.green;
        }
        if(food_production2.value < 0.25f){
            food2_text.color = Color.green;
        }
        if(food_production_now.value < 0.25f){
            food_text_now.color = Color.red;
        }
        if(Industry.value < 0.25f){
            industry1_text.color = Color.green;
        }
        if(Industry2.value < 0.25f){
            industry2_text.color = Color.green;
        }
        if(industry_now.value < 0.25f){
            industry_text_country.color = Color.red;
        }
        if(torisum.value < 0.25f){
            torisum1_text.color = Color.green;
        }
        if(torisum2.value < 0.25f){
            torisum2_text.color = Color.green;
        }
        if(torisum_now.value < 0.25f){
            torisum_text_now.color = Color.red;
        }
        if(culture.value < 0.25f){
            culture1_text.color = Color.green;
        }
        if(culture2.value < 0.25f){
            culture2_text.color = Color.green;
        }
        if(culture_now.value < 0.25f){
            culture_text_now.color = Color.red;
        }
        if(money.value < 0.25f){
            money1_text.color = Color.green;
            
        }
        if(money2.value < 0.25f){
            money2_text.color = Color.green;
        }
        if(money_now.value < 0.25f){
            money_text_country.color = Color.red;
        }
        if(population.value < 0.25f){
            population_text1.color = Color.green;
        }
        if(population2.value < 0.25f){
            population_text2.color = Color.green;
        }
        if(population_now.value < 0.25f){
            population_text_country.color = Color.red;
        }
        if(education.value < 0.25f){
            education1_text.color = Color.green;
        }
        if(education2.value < 0.25f){
            education2_text.color = Color.green;
        }
        if(education_now.value < 0.25f){
            education_text_now.color = Color.red;
        }
        if(food_production.value < 0.25f){
            food1_text.color = Color.green;
        }
        if(food_production2.value < 0.25f){
            food2_text.color = Color.green;
        }
        if(food_production_now.value < 0.25f){
            food_text_now.color = Color.red;
        }
        if(Industry.value < 0.25f){
            industry1_text.color = Color.green;
        }
        if(Industry2.value < 0.25f){
            industry2_text.color = Color.green;
        }
        if(industry_now.value < 0.25f){
            industry_text_country.color = Color.red;
        }
        if(torisum.value < 0.25f){
            torisum1_text.color = Color.green;
        }
        if(torisum2.value < 0.25f){
            torisum2_text.color = Color.green;
        }
        if(torisum_now.value < 0.25f){
            torisum_text_now.color = Color.red;
        }
        if(culture.value < 0.25f){
            culture1_text.color = Color.green;
        }
        if(culture2.value < 0.25f){
            culture2_text.color = Color.green;
        }
        if(culture_now.value < 0.25f){
            culture_text_now.color = Color.red;
        }
        if(money.value < 0.25f){
            money1_text.color = Color.green;
            
        }
        if(money2.value < 0.25f){
            money2_text.color = Color.green;
        }
        if(money_now.value < 0.25f){
            money_text_country.color = Color.red;
        }
        //red
        
        if(population.value < 0.5f){
            population_text1.color = Color.red;
        }
        if(population2.value < 0.5f){
            population_text2.color = Color.red;
        }
        if(population_now.value < 0.5f){
            population_text_country.color = Color.red;
        }
        if(education.value < 0.5f){
            education1_text.color = Color.red;
        }
        if(education2.value < 0.5f){
            education2_text.color = Color.red;
        }
        if(education_now.value < 0.5f){
            education_text_now.color = Color.red;
        }
        if(food_production.value < 0.5f){
            food1_text.color = Color.red;
        }
        if(food_production2.value < 0.5f){
            food2_text.color = Color.red;
        }
        if(food_production_now.value < 0.5f){
            food_text_now.color = Color.red;
        }
        if(Industry.value < 0.5f){
            industry1_text.color = Color.red;
        }
        if(Industry2.value < 0.5f){
            industry2_text.color = Color.red;
        }
        if(industry_now.value < 0.5f){
            industry_text_country.color = Color.red;
        }
        if(torisum.value < 0.5f){
            torisum1_text.color = Color.red;
        }
        if(torisum2.value < 0.5f){
            torisum2_text.color = Color.red;
        }
        if(torisum_now.value < 0.5f){
            torisum_text_now.color = Color.red;
        }
        if(culture.value < 0.5f){
            culture1_text.color = Color.red;
        }
        if(culture2.value < 0.5f){
            culture2_text.color = Color.red;
        }
        if(culture_now.value < 0.5f){
            culture_text_now.color = Color.red;
        }
        if(money.value < 0.5f){
            money1_text.color = Color.red;
            
        }
        if(money2.value < 0.5f){
            money2_text.color = Color.red;
        }
        if(money_now.value < 0.5f){
            money_text_country.color = Color.red;
        }
        //green

        if(population.value < 0.5f){
            population_text1.color = Color.green;
        }
        if(population2.value < 0.5f){
            population_text2.color = Color.green;
        }
        if(population_now.value < 0.5f){
            population_text_country.color = Color.red;
        }
        if(education.value < 0.5f){
            education1_text.color = Color.green;
        }
        if(education2.value < 0.5f){
            education2_text.color = Color.green;
        }
        if(education_now.value < 0.5f){
            education_text_now.color = Color.red;
        }
        if(food_production.value < 0.5f){
            food1_text.color = Color.green;
        }
        if(food_production2.value < 0.5f){
            food2_text.color = Color.green;
        }
        if(food_production_now.value < 0.5f){
            food_text_now.color = Color.red;
        }
        if(Industry.value < 0.5f){
            industry1_text.color = Color.green;
        }
        if(Industry2.value < 0.5f){
            industry2_text.color = Color.green;
        }
        if(industry_now.value < 0.5f){
            industry_text_country.color = Color.red;
        }
        if(torisum.value < 0.5f){
            torisum1_text.color = Color.green;
        }
        if(torisum2.value < 0.5f){
            torisum2_text.color = Color.green;
        }
        if(torisum_now.value < 0.5f){
            torisum_text_now.color = Color.red;
        }
        if(culture.value < 0.5f){
            culture1_text.color = Color.green;
        }
        if(culture2.value < 0.5f){
            culture2_text.color = Color.green;
        }
        if(culture_now.value < 0.5f){
            culture_text_now.color = Color.red;
        }
        if(money.value < 0.5f){
            money1_text.color = Color.green;
            
        }
        if(money2.value < 0.5f){
            money2_text.color = Color.green;
        }
        if(money_now.value < 0.5f){
            money_text_country.color = Color.red;
        }
    }

}
 