using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_Air : MonoBehaviour
{
    [Header("GameObjects")]
    GameObject GOnamlu,GOplayer;

    [Header("BOOL")]
    bool asagiMiYukariMiVuracak = false;

    [Header("Int-Float")]
    public int level = 0;
    float namluMaxRotation = 182,namluMinRotation=-2;
    public float powerOfMiss=2f;//Kaçırma mesafesi
    
    [Header("Others")]
    int kindOfAnti_air;//0=Low Damage,1=Normal Damage,2=Hıgh Damage ---- Anti_Air_LowDamage----Anti_Air_NormalDamage---Anti_Air_BigDamage

    [Header("Level")]
    int[] levelDifficult = new int[10];
    void Start()
    {
        GOnamlu = this.gameObject.transform.GetChild(0).gameObject;//Namluyu tanıttık.

        if (gameObject.transform.name == "Anti_Air_LowDamage")//
            kindOfAnti_air = 0;
        else if (gameObject.transform.name == "Anti_Air_NormalDamage") 
            kindOfAnti_air = 1;
        else 
            kindOfAnti_air = 2;

        levelDifficult = gameManager.Instance.aaLevelDifficulty;//level zorluğu gameManagerdeb çekiliyor.
        GOplayer = gameManager.Instance.player;//Player gameManagerden çekildi

        Debug.Log(Random.Range(-1, 1));
        if (Random.Range(-1, 1) == 0)//Altına mı Yukarısına mı Vuracak?
            asagiMiYukariMiVuracak = true;
    }

    void Update()
    {

        #region OrtakKodlar

        Vector3 DifficultyRandom;
            if (asagiMiYukariMiVuracak)
            //LEvel arttıkça ıskalama oranının düşmesi
            DifficultyRandom = new Vector3(GOplayer.gameObject.transform.position.x + ((100.0f - (float)levelDifficult[level]) / 100.0f * powerOfMiss), GOplayer.gameObject.transform.position.y + ((100.0f - (float)levelDifficult[level]) / 100.0f * powerOfMiss), GOplayer.gameObject.transform.position.z);
            else
            DifficultyRandom = new Vector3(GOplayer.gameObject.transform.position.x - ((100.0f - (float)levelDifficult[level]) / 100.0f * powerOfMiss), GOplayer.gameObject.transform.position.y - ((100.0f - (float)levelDifficult[level]) / 100.0f * powerOfMiss), GOplayer.gameObject.transform.position.z);


            ///Playere bakma
            Vector3 dir = DifficultyRandom - GOnamlu.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion clampedRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            clampedRotation.z = Mathf.Clamp(clampedRotation.z, namluMinRotation, namluMaxRotation);//Max min namluyu ayarlama
            GOnamlu.gameObject.transform.rotation = clampedRotation;
            ///

        #endregion
    }
}

/*
 (100f-80f)/10f*  5f = 0f;

 */
