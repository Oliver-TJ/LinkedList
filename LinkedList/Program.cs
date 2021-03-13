using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new LinkedList();
            list1.ListOutputActual();
            list1.ListOutput();
        }
    }

    class LinkedList
    {
        private int _nextFree = 0;
        private int _start = 0;
        private readonly string[,] _string1 = new string[10, 2];
        private int temp;
        private int p;
        private bool placeFound;
        
        

        public void AddItem(string item)
        {
            if (_nextFree == -1)
            {
                Console.WriteLine($"List Full, cannot add '{item}'");
            }
            else
            {
                _string1[_nextFree, 0] = item;
                if (_start == -1)
                {
                    temp = Convert.ToInt16(_string1[_nextFree, 1]);
                    _string1[_nextFree, 1] = "-1";
                    _start = _nextFree;
                    _nextFree = temp;
                }
                else
                {
                    p = _start;
                    if (_nextFree == -1)
                    {
                        _string1[_nextFree, 1] = Convert.ToString(_start);
                        _start = _nextFree;
                    }
                    else
                    {
                        placeFound = false;
                        while (_string1[p, 1] != "-1" && placeFound == false)
                        {
                            if (Convert.ToInt16(_string1[_nextFree, 1]) >= Convert.ToInt16(_string1[p, 1]))
                            {
                                p = Convert.ToInt16(_string1[p, 1]);
                            }
                            else
                            {
                                placeFound = true;
                            }
                        }

                        temp = _nextFree;
                        _nextFree = Convert.ToInt16(_string1[temp, 1]);
                        _string1[temp, 1] = _string1[p, 1];
                        _string1[p, 1] = Convert.ToString(temp);
                    }

                }
            }
        }

        public void ListOutputActual()
        {
            _string1[0, 0] = "Test Input";
            _string1[0, 1] = "3";
            _string1[3, 0] = "Test 2";
            _string1[3, 1] = "-1";
            for (int i = 0; i < _string1.GetLength(0); i++)
            {
                Console.WriteLine(i + ". " + _string1[i, 0]);
            }
        }

        public void ListOutput()
        {
            _string1[0, 0] = "Test Input";
            _string1[0, 1] = "3";
            _string1[3, 0] = "Test 2";
            _string1[3, 1] = "-1";
            p = _start;
            for (int i = 0;_string1.GetLength(0)>i; i++)
            {
                if (Convert.ToInt16(_string1[p, 1]) != -1)
                {
                    Console.WriteLine((i)+"."+_string1[p, 0]); 
                    p = Convert.ToInt16(_string1[p, 1]);
                }
                else
                {
                    Console.WriteLine((i)+"."+_string1[p, 0]); 
                    break;
                }
                
            }
        }

        public void DeleteItem(string deleteName)
        {
            if (_start == -1)
            {
                Console.WriteLine($"List is empty, cannot remove '{deleteName}'");
            }
            else
            {
                p = _start;
                if (deleteName == _string1[_start, 0])
                {
                    _start = Convert.ToInt16(_string1[_start, 1]);
                }
                else
                {
                    while (deleteName != _string1[Convert.ToInt16(_string1[p, 1]), 0])
                    {
                        p = Convert.ToInt16(_string1[p, 1]);
                    }
                }

                temp = Convert.ToInt16(_string1[p, 1]);
                _string1[p, 1] = _string1[temp, 1];
                _string1[p, 1] = Convert.ToString(_nextFree);
                _nextFree = temp;
            }
        }
    }
}