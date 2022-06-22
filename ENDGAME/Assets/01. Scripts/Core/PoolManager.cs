using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    public static Dictionary<string, object> pool = new Dictionary<string, object>();
    public static Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();

    //Ǯ�� �ϳ� ���� ����� �Լ� AfterImage, Bullet, Projectile
    public static void CreatePool<T>(GameObject prefab, Transform parent, int count = 5)
    {
        // � �����յ�� Ǯ�� ���鲨��? �ش� �����յ��� ������ �ڽ�����? ��� ���鲨��?
        Queue<T> q = new Queue<T>();
        //Ǯ�� ť�� �����Ҳ���. ������ TŸ���� ť�� ����°�
        for (int i = 0; i < count; i++)
        {
            //�ش� ť�� prefab�� ������ ������ŭ ���� �־��ش�.
            GameObject g = GameObject.Instantiate(prefab, parent);

            T t = g.GetComponent<T>();
            g.SetActive(false);
            //������� ���ӿ�����Ʈ�� ���ݴ��� ���� �ƴϱ� ������ active false�� �س��´�.
            q.Enqueue(t);
        }

        //Type type = typeof(T);

        string key = typeof(T).ToString();
        //�� key���� "AfterImage"
        pool.Add(key, q);
        //��ųʸ��� "AfterImage"��� Ű ������ Queue<AfterImage>�� �߰��Ѵ�.
        prefabDictionary.Add(key, prefab);
        //�׸��� �߰������� �� ���� ���� ������ prefab�� ������ �д�.
    }

    //�׷��� ������� Ǯ���� ���ϴ� �� ã�ƿ��� �ڵ��.
    public static T GetItem<T>() where T : MonoBehaviour
    {
        //���� T�� AfterImage ã�ƿ��� �ɷ� �����ϰ� �����غ���
        string key = typeof(T).ToString();
        //T���� "AfterImage"��� ���ڿ��� �̾Ƴ��� ���ؼ� Type�� �����ͼ� ToString���� ���ڿ��� �̴´�.
        T item = null;
        //�״����� ������ item�� ������ְ� null�� �ʱ�ȭ �Ѵ�.

        if (pool.ContainsKey(key))
        {
            //Ǯ�� �ش��ϴ� key�� �����ϸ� 
            Queue<T> q = (Queue<T>)pool[key];
            //Ǯ ��ųʸ����� �ش� Ű�� Queue<AfterImage> �� �����´�. �̶� object �̹Ƿ� ����ȯ�Ѵ�.
            T firstItem = q.Peek();
            // ť�� ù��° �������� ���캸������ Peek�� �Ἥ ��������(�̶� ť���� �̾Ƴ����� �ʴ´�)
            if (firstItem.gameObject.activeSelf)
            {
                //�ش� �������� ���� ������̶�� ť ��ü�� ������ΰ����� �Ǵ��ϰ� 
                //���Ӱ� �����.
                GameObject prefab = prefabDictionary[key];
                //�������� �����ͼ�
                GameObject g = GameObject.Instantiate(prefab, firstItem.transform.parent);
                //�ٽ� �����ϰ�
                item = g.GetComponent<T>();
                //�ű⼭ AfterImage ��ũ��Ʈ�� �̴´�.
            }
            else
            {
                //�׷��� �ʴٸ� ��������� �����Ŵϱ� ť���� ������
                item = q.Dequeue();
                item.gameObject.SetActive(true);
                //Ȱ��ȭ�� �����ش�.
            }
            q.Enqueue(item);
            //�ٽ� ť�� �� ���������� �־��ش�.
        }

        return item;
    }

}
