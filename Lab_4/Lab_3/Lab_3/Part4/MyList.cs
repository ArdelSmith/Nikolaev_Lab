using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_3.Part4
{
    public class MyList<T> : IEnumerable<T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        // Возвращает первый элемент списка
        public T GetFirstElem()
        {
            return head.Data;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public bool Remove(Node<T> data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data.ToString());
                current = current.Next;
            }
        }

        public void Reverse() // 1 метод
        {
            Node<T> p = head, n = null;
            tail = head;
            while (p != null)
            {
                Node<T> tmp = p.Next;
                p.Next = n;
                n = p;
                p = tmp;
            }

            head = n;
        }

        public void SwapHeadAndTail() // 2 метод смена местами первого и последнего элемента
        {
            var tmp = head.Data;
            head.Data = tail.Data;
            tail.Data = tmp;
        }

        public int FindCountUniqueElements() // 3 метод определяет количество различных элементов списка, содержащего целые числа
        {
            MyList<T> buf = new MyList<T>();

            Node<T> current = head;
            buf.Add(current.Data);
            while (current != null)
            {
                if (!buf.Contains(current.Data))
                {
                    buf.Add(current.Data);
                }
                current = current.Next;
            }

            return buf.Count;
        }

        public bool RemoveDuplicateElement(T data) // 4 метод
        {
            bool flag = false; // найден ли первый элемент

            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data) && flag)
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                if (current.Data.Equals(data) && !flag)
                {
                    flag = true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void InsertAllValuesAfter(T data) // 5 метод
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    var before = current.Next;
                    Node<T> node = new Node<T>(head.Data);

                    var lastSize = Count;

                    MyList<T> buf = new MyList<T>(); // занесли все значения
                    var headBuf = buf.head;
                    buf.Add(node.Data);
                    var currentNew = head.Next;

                    while (currentNew != null)
                    {
                        buf.Add(currentNew.Data);
                        currentNew = currentNew.Next;
                    }

                    var currentBuf = buf.head;

                    while (currentBuf != null)
                    {
                        current.Next = currentBuf;
                        current = current.Next;
                        currentBuf = currentBuf.Next;
                    }

                    count += lastSize;
                    current.Next = before;
                    return;
                }
                current = current.Next;
            }
        }

        public void InsertBySort(T data) // 6 метод - вставка в нужно место, чтобы сохранить возрастание
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (count == 1)
            {
                if (Convert.ToInt32(head.Data) < Convert.ToInt32(data))
                {
                    Add(data);
                }
                else
                {
                    AppendFirst(data);
                }
                return;
            }

            if (Convert.ToInt32(head.Data) > Convert.ToInt32(data))
            {
                AppendFirst(data);
                return;
            }

            while (current != null)
            {
                if (Convert.ToInt32(current.Data) > Convert.ToInt32(data) && Convert.ToInt32(previous.Data) < Convert.ToInt32(data))
                {
                    Node<T> node = new Node<T>(data);
                    node.Next = current;
                    previous.Next = node;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public bool RemoveAllDuplicates(T data) // 7 метод - удаление всех дубликатов
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void InsertElementAfterFirstFind(T dataF, T dataE) // 8 метод - вставить элемент перед первым вхождение элемента data
        {
            if (Contains(dataE))
            {
                if (count == 1)
                {
                    AppendFirst(dataF);
                    return;
                }
                else
                {
                    Node<T> current = head;
                    Node<T> previous = null;
                    int i = 0;
                    while (current != null)
                    {
                        if (current.Data.Equals(dataE))
                        {
                            if (i == 0)
                            {
                                AppendFirst(dataF);
                                return;
                            }
                            else
                            {
                                Node<T> node = new Node<T>(dataF);
                                node.Next = current;
                                previous.Next = node;
                                return;
                            }
                        }
                        i++;
                        previous = current;
                        current = current.Next;
                    }
                }
            }
        }

        public void AddByFile(string nameFile) // 9 метод - добавление в список из файла
        {
            using (StreamReader fs = new StreamReader(nameFile, Encoding.ASCII))
            {
                string line;
                while ((line = fs.ReadLine()) != null)
                {
                    var splitLine = line.Split(' ');

                    foreach (var item in splitLine)
                    {
                        Add((T)Convert.ChangeType(item, typeof(T)));
                    }
                }
            }
        }

        public MyList<T> Split(T data) // 10 метод - разбить список на два по первому вхождению значения
        {
            MyList<T> tmp = new MyList<T>();

            var current = head;
            bool flag = false;
            bool isFirst = false;
            Node<T> prev = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    flag = true;
                    isFirst = true;
                }

                if (isFirst)
                {
                    tmp.Add(current.Data);

                }

                prev = current;
                current = current.Next;

                if (isFirst)
                {
                    Remove(prev);
                }
            }

            return tmp;
        }

        public void Multiply() // 11 метод - скопировать список в конец
        {
            MyList<T> buf = new MyList<T>();

            Node<T> current = head;

            while (current != null)
            {
                buf.Add(current.Data);
                current = current.Next;
            }

            current = buf.head;
            while (current != null)
            {
                Add(current.Data);
                current = current.Next;
            }
        }

        public void Swap(T dataA, T dataB) // 12 метод
        {
            Node<T> current = head;

            Node<T> a = null;
            Node<T> b = null;

            bool isFirstA = false;
            bool isFirstB = false;

            while (current != null)
            {
                if (current.Data.Equals(dataA) && !isFirstA)
                {
                    a = current;
                    isFirstA = true;
                }

                if (current.Data.Equals(dataB) && !isFirstB)
                {
                    b = current;
                    isFirstB = true;
                }

                current = current.Next;
            }

            a.Data = dataB;
            b.Data = dataA;
        }
    }
}


