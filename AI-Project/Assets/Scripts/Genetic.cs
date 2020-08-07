using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Genetic : MonoBehaviour
{
    int i, j;
    public string[] array = new string[20];
    public bool[] isAlive = new bool[20];
    public int[,] score = new int[20,2];
    public int count = 0;
    public string[] new_array = new string[20];
    public string result;
    public string result1;
    public int iteration = 0;
    public int max_iteration = 50;

    static string ReplaceAtIndex(int i, char value, string word)
    {
        char[] letters = word.ToCharArray();
        letters[i] = value;
        return string.Join("", letters);
    }

    /*
    mutation() fonksiyonu 1 parametre alır:
    1) array: yolların tutulduğu matris
    mutation() fonksiyonu ile rastgele seçilen bireylere mutasyon uygulanır.
    Belirlenen oran kadar (0,1) uygulanan mutasyon rastgele değerlerin değişmesi ile yapılır.
        mutation_Rate = 0.1; 
    array döndürülür. */
    public string[] mutation()
    {
        System.Random random = new System.Random();

        int prob = (int)(0.5 * FindObjectOfType<init>().move_count * FindObjectOfType<init>().player_size);
        for (i = 0; i < prob; i++)
        {
            int row = random.Next(0, FindObjectOfType<init>().player_size);
            int coloumn = random.Next(0, FindObjectOfType<init>().move_count);
            int rnd = random.Next(0, 3);
            switch (rnd)
            {
                case 0:
                    ReplaceAtIndex(coloumn, 'a', array[row]);
                    break;
                case 1:
                    ReplaceAtIndex(coloumn, 'w', array[row]);
                    break;
                case 2:
                    ReplaceAtIndex(coloumn, 'd', array[row]);
                    break;
            }
             
        }
        return array;
    }

    /*
    crossover() fonksiyonu 1 parametre alır:
    1) array: yolların tutulduğu matris
    selection() fonksiyonu ile seçilen bireyler arasında çaprazlama uygulanır.
    Çaprazlama yapılırken rastgele belirlenen bir noktadan bölünürler.
    array döndürülür. */
    public string[] crossover()
    {
        System.Random random = new System.Random();
        
        
        for(i=0;i< FindObjectOfType<init>().player_size / 2; i++)
        {
            int line = random.Next(0, FindObjectOfType<init>().move_count);
            result = array[2 * i].Substring(0, line);
            result += array[2 * i + 1].Substring(line, FindObjectOfType<init>().move_count-line);

            result1 = array[2 * i + 1].Substring(0, line);
            result1 += array[2 * i].Substring(line, FindObjectOfType<init>().move_count-line);
            new_array[2 * i] = result;
            new_array[2 * i + 1] = result1;
        }
        array = new_array;
        return array;

    }

    /*
    selection() fonksiyonu 1 parametre alır:
    1) array: yolların tutulduğu matris
    Bireylerin skorlarına göre score dizisi ve array sıralanır.
    Bireylerin seçilme olasılıkları hesaplanıp bir sonraki
    nesli oluşturacak bireyler seçilip array değişkenine atanır.
        array döndürülür. */
    public string[] selection()
    {
        for(i=0;i< FindObjectOfType<init>().player_size-1; i++)
        {
            int smallest = i;
            for (j = i+1; j < FindObjectOfType<init>().player_size; j++)
            {
                if(score[j,0] > score[smallest,0])
                {
                    smallest = j;
                }
            }

            int temp = score[smallest,0];
            score[smallest, 0] = score[i, 0];
            score[i, 0] = temp;
            temp = score[smallest, 1];
            score[smallest, 1] = score[i, 1];
            score[i, 1] = temp;
        }

    System.Random random = new System.Random();
        for (i = 0; i < FindObjectOfType<init>().player_size; i++)
        {
            int no = random.Next(0, 5);
            int indis = score[no, 1];
            new_array[i] = array[indis];
        }
        array = new_array;
        return array;
    }

    /*
     1 - a (sol)
     2 - w (düz)
     3 - d (sağ)
         */
    public string[] createPath()
    {
        Array.Clear(array, 0, array.Length);
        System.Random random = new System.Random();
        for (j = 0; j < FindObjectOfType<init>().player_size; j++)
        {
            for (i = 0; i < FindObjectOfType<init>().move_count; i++)
            {
                // 0 a , 1 w , 2 d
                switch (random.Next(0, 3))
                {
                    case 0:
                        array[j] += 'a';
                        break;
                    case 1:
                        array[j] += 'w';
                        break;
                    case 2:
                        array[j] += 'd';
                        break;
                }
            }
            isAlive[j] = true;
        }
        DontDestroyOnLoad(this);
        return array;
    }

    public bool[] checkPath()
    {
        for (j = 0; j < FindObjectOfType<init>().player_size; j++)
        {
            isAlive[j] = true;
        }
        DontDestroyOnLoad(this);
        //print("yeni isalive1");
        return isAlive;
    }


    // Start is called before the first frame update
    void Start()
    {
        for (j = 0; j < FindObjectOfType<init>().player_size; j++)
        {
            score[j,0] = 0;
            score[j,1] = j;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
