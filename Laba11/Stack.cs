using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLaba10;

namespace Laba11
{
    internal class MyStack
    {
        internal class Stack : IEnumerable<Plants>
        {
            private System.Collections.Generic.Stack<Plants> stack;
            int capacity;
            int count;

            public int Capacity
            {
                get => capacity;
                private set => capacity = value;
            }
            public int Count { get => count; }

            public Stack()
            {
                Capacity = 0;
                stack = new System.Collections.Generic.Stack<Plants>();
                count = 0;
            }
            public Stack(int capacity)
            {
                if (capacity < 0)
                    throw new ArgumentException();
                this.capacity = capacity;
                count = 0;
                stack = new System.Collections.Generic.Stack<Plants>(capacity);
            }

            public Stack(ICollection<Plants> c)
            {
                if (c.Count == 0)
                {
                    Capacity = 0;
                    stack = new System.Collections.Generic.Stack<Plants>();
                    count = 0;
                    return;
                }
                this.capacity = c.Count;
                count = 0;
                stack = new System.Collections.Generic.Stack<Plants>(c);
                count = c.Count;
            }

            /// <summary>
            /// В методе Add создается временный стек tempStack, которое используется для увеличения емкости основного стека stack. 
            /// Происходит копирование всех элементов из основного стека во временный, затем добавляется новый элемент во временый стек.
            /// Затем возвращаются элементы из временного стека обратно в основной стек. 
            /// </summary>
            /// <param name="item"></param>
            /// <exception cref="ArgumentNullException"></exception>
            public void Add(Plants item)
            {
                if (item == null)
                    throw new ArgumentNullException();
                if (Count < Capacity)
                {
                    stack.Push(item);
                }
                else
                {
                    Capacity *= 2;
                    System.Collections.Generic.Stack<Plants> tempStack = new System.Collections.Generic.Stack<Plants>();
                    while (stack.Count > 0)
                    {
                        tempStack.Push(stack.Pop());
                    }
                    tempStack.Push(item);
                    while (tempStack.Count > 0)
                    {
                        stack.Push(tempStack.Pop());
                    }
                }
                count++;
            }

            /// <summary>
            /// Cоздается временный стек tempStack, из которого мы извлекаем элементы до тех пор, пока не найдем элемент для удаления. 
            /// Затем копируются элементы обратно в исходный стек stack, кроме удаленного элемента. 
            /// </summary>
            /// <param name="item"></param>
            /// <exception cref="ArgumentNullException"></exception>
            public void Remove()
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                    count--;
                }
                else
                {
                    Console.WriteLine("Стек пуст, невозможно удалить элемент.");
                }
                if (Count < Capacity / 2)
                {
                    Capacity /= 2;
                    System.Collections.Generic.Stack<Plants> tempStack1 = new System.Collections.Generic.Stack<Plants>();
                    while (stack.Count > 0)
                    {
                        tempStack1.Push(stack.Pop());
                    }
                    stack = tempStack1;
                }
            }

            /// <summary>
            /// Метод для сортировки стека
            /// </summary>
            /// <param name="stack"></param>
            /// <returns></returns>
            public System.Collections.Generic.Stack<Plants> SortStack(Stack<Plants> stack)
            {
                System.Collections.Generic.Stack<Plants> tempStack = new System.Collections.Generic.Stack<Plants>();
                foreach (Plants item in stack)
                {
                    tempStack.Push(item);
                }
                if (tempStack == null || tempStack.Count <= 1)
                {
                    return tempStack; // Нечего сортировать, если стек пуст или содержит один элемент
                }
                // Перевод стекa в массив для сортировки
                Plants[] array = tempStack.ToArray();
                Array.Sort(array);
                // Создание нового стека для хранения отсортированных элементов
                System.Collections.Generic.Stack<Plants> sortedStack = new System.Collections.Generic.Stack<Plants>();
                // Перевод отсортированного массива обратно в стек
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    sortedStack.Push(array[i]);
                }
                return sortedStack;
            }

            /// <summary>
            /// Метод для поиска элементов стека
            /// </summary>
            /// <param name="stack"></param>
            /// <param name="plants"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public int Search(System.Collections.Generic.Stack<Plants> stack, Plants plants)
            {
                if (stack == null || plants == null)
                {
                    throw new ArgumentNullException();
                }

                int index = 0;
                foreach (Plants item in stack)
                {
                    if (plants.Equals(item))
                    {
                        return index;
                    }
                    index++;
                }

                return -1; // Если объект не был найден в стеке
            }

            /// <summary>
            /// Метод для клонирования стека
            /// </summary>
            /// <returns></returns>
            public Stack<Plants> CloneStack()
            {
                Stack<Plants> cloneStack = new Stack<Plants>();
                foreach (Plants item in this) { cloneStack.Add(item); }
                return cloneStack;

            }

            public IEnumerator<Plants> GetEnumerator()
            {
                return ((IEnumerable<Plants>)stack).GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)stack).GetEnumerator();
            }

        }
    }
}
