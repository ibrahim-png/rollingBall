using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class roadScript : MonoBehaviour
{
    private GameObject _createdBlock;
    public GameObject roadPrefab;
    public GameObject diamondPrefab;
    public GameObject blockPrefab;


    public GameObject pointballPrefab;



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "mainSphere")
        {

            var olusanYol= Instantiate(roadPrefab, new Vector3(transform.position.x , transform.position.y , transform.position.z), Quaternion.identity );
            olusanYol.transform.position += new Vector3(transform.GetComponent<Renderer>().bounds.size.x * -1, 0, 0); //yolu en uca tasıyor

            for (int i = 0; i < 8; i++)
            {
                createEnvironment(i);
            }
          
        }
        
    }

     void createEnvironment(int kacinciLoop)
    {


   


        int randomInt = UnityEngine.Random.Range(1,4);
        Debug.Log("random olarak gelen sayı = " + randomInt.ToString());
        if (randomInt == 1)
        {
            createDiamond(kacinciLoop); //diamond olustur
        }
        else if (randomInt == 2)
        {
            createBlock(kacinciLoop); // block olustur
        }
        else if (randomInt == 3)
        {
            createPointBall(kacinciLoop); // pointballOlustur
        }
    }

    void createDiamond(int kacinciLoop)
    {
        float road1bolu7 = transform.GetComponent<Renderer>().bounds.size.x * -1 / 7;
        float road1bolu2 = transform.GetComponent<Renderer>().bounds.size.x * -1 / 2;

        Vector3 diamondVector = new Vector3((transform.position.x + road1bolu2) + (road1bolu7 * kacinciLoop), 1, UnityEngine.Random.Range(-3, 4));

        for (int i = 0; i < UnityEngine.Random.Range(5, 15) ; i++)
        {


           Instantiate(diamondPrefab, diamondVector + (new Vector3(2 * i, 0, 0)), Quaternion.identity);
           //GameObject gO = objectPool.Instance.GetPooledObject(0); // create diamond
           // Vector3 vector3pos = diamondVector + new Vector3(2 * i, 0, 0);
           // gO.transform.position = vector3pos;
        }

        
       
    }
    void createBlock(int kacinciLoop)
    {
        float road1bolu7 = transform.GetComponent<Renderer>().bounds.size.x * -1 / 7;
        float road1bolu2 = transform.GetComponent<Renderer>().bounds.size.x * -1 / 2;
        float blockYukseklik = 0;




        for (int i = 0; i < UnityEngine.Random.Range(2, 6); i++)
        {
            int whichBlock = UnityEngine.Random.Range(1, 8);

        switch (whichBlock)
        {
            case 1:
                blockYukseklik = .5f;
                break;
            case 2:
                blockYukseklik = 1f;
                break;
            case 3:
                blockYukseklik = 1.5f;
                break;
            case 4:
                blockYukseklik = 2f;
                break;
            case 5:
                blockYukseklik = 3f;
                break;
            case 6:
                blockYukseklik = 0f;
                break;
            case 7:
                blockYukseklik = 0f;
                break;
                default:
            print("Incorrect intelligence level.");
                break;
        }


        Vector3 blockVector = new Vector3((transform.position.x + road1bolu2) + (road1bolu7 * kacinciLoop), blockYukseklik , 0);

            float blockZaxisFloat = UnityEngine.Random.Range(-3.5f, 3.5f);
            if ( -3.5f < blockZaxisFloat && blockZaxisFloat < -2.5f)
            {
                blockZaxisFloat = -2.5f;
            }
            else if (-2.5f < blockZaxisFloat && blockZaxisFloat < -1.5f)
            {
                blockZaxisFloat = -1.5f;
            }
            else if (-1.5f < blockZaxisFloat && blockZaxisFloat < -.5f)
            {
                blockZaxisFloat = -.5f;
            }
            else if (-.5f < blockZaxisFloat && blockZaxisFloat < .5f)
            {
                blockZaxisFloat = .5f;
            }
            else if (.5f < blockZaxisFloat && blockZaxisFloat < 1.5f)
            {
                blockZaxisFloat = 1.5f;
            }
            else if (1.5f < blockZaxisFloat && blockZaxisFloat < 4.5f)
            {
                blockZaxisFloat = 2.5f;
            }

          
            Vector3 vector3pos = blockVector + (new Vector3(8 * i, 0, blockZaxisFloat));
            

            switch (whichBlock)
            {
                case 1:

                    //Instantiate(block_1yukseklik_yarimGenislik, transform.position + diamondVector + (new Vector3(8 * i, 0, blockZaxisFloat)), Quaternion.identity);
                      _createdBlock = objectPool.Instance.GetPooledObject(1); // create diamond
                     break;
                case 2:
                    _createdBlock = objectPool.Instance.GetPooledObject(2); // create blok
                    break;
                case 3:
                    _createdBlock = objectPool.Instance.GetPooledObject(3); // create blok
                    break;
                case 4:
                    _createdBlock = objectPool.Instance.GetPooledObject(4); // create blok
                    break;
                case 5:
                    _createdBlock = objectPool.Instance.GetPooledObject(5); // create blok
                    break;
                case 6:
                    _createdBlock = objectPool.Instance.GetPooledObject(7); // create blok (umbrella)
                    break;
                case 7:
                    _createdBlock = objectPool.Instance.GetPooledObject(8); // create blok (chair)
                    break;
                default:
                    print("do not exist");
                    break;
            }
            _createdBlock.transform.position = vector3pos;
        }
        


    }

    void createPointBall(int kacinciLoop)
    {
        float road1bolu7 = transform.GetComponent<Renderer>().bounds.size.x * -1 / 7;
        float road1bolu2 = transform.GetComponent<Renderer>().bounds.size.x * -1 / 2;

        Vector3 diamondVector = new Vector3((transform.position.x + road1bolu2) + (road1bolu7 * kacinciLoop), .5f , UnityEngine.Random.Range(-2.5f, 2.5f));
        
        float diamondZaxis = UnityEngine.Random.Range(-2, 3);


        for (int i = 0; i < UnityEngine.Random.Range(1, 6); i++)
        {
            Instantiate(pointballPrefab, diamondVector + (new Vector3(3 * i, 0, diamondZaxis)), Quaternion.identity);
            //GameObject createdPointBall =  objectPool.Instance.GetPooledObject(6);
            //createdPointBall.transform.position = diamondVector + (new Vector3(3 * i, 0, diamondZaxis));
        }

      
    }
}
