using ClassLibraryLaba10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
{
    internal class TestCollections<TValue, TKey> where TValue : TKey
    {
        HashSet<Plants> collection1 = new HashSet<Plants>();
        HashSet<string> collection2 = new HashSet<string>();
        Dictionary<Plants, Flowers> collection3 = new Dictionary<Plants, Flowers>();
        Dictionary<string, Flowers> collection4 = new Dictionary<string, Flowers>();

        Flowers first, middle, last, noexist;

        // Конструктор класса
        public TestCollections(int lenght)
        {
            noexist = new Flowers();
            noexist.RandomInit();
            for (int i = 0; i < lenght; i++) 
            {
                try
                {
                    Flowers flower = new Flowers();
                    flower.RandomInit();
                    flower.Name += i.ToString();
                    collection1.Add(flower.BasePlant);
                    collection2.Add(flower.BasePlant.ToString());
                    collection3.Add(flower.BasePlant, flower);
                    collection4.Add(flower.BasePlant.ToString(), flower);

                    if (i == 0)
                        first = (Flowers)flower.Clone();
                    if (i == lenght/2)
                        middle = (Flowers)flower.Clone();
                    if(i == lenght - 1)
                        last = (Flowers)flower.Clone();
                }
                catch
                {
                    i--;
                }
            }
        }
        public double TimeSearchFirstElementCollection1()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsFirstCollection1 = collection1.Contains(first.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection2()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsFirstCollection2 = collection2.Contains(first.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection3()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsFirstCollection3 = collection3.ContainsKey(first.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection3Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsFirstCollection3 = collection3.ContainsValue(first);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection4()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsFirstCollection4 = collection4.ContainsKey(first.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchFirstElementCollection4Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsFirstCollection4 = collection4.ContainsValue(first);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchMiddleElementCollection1()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsMiddle = collection1.Contains(last.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchMiddleElementCollection2()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsMiddle = collection2.Contains(middle.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchMiddleElementCollection3()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsMiddle = collection3.ContainsKey(middle.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchMiddleElementCollection3Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = collection3.ContainsValue(middle);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchMiddleElementCollection4()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsMiddle = collection4.ContainsKey(middle.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchMiddleElementCollection4Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = collection4.ContainsValue(middle);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchLastElementCollection1()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsLast = collection1.Contains(middle.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchLastElementCollection2()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsLast = collection2.Contains(last.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchLastElementCollection3()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsLast = collection3.ContainsKey(last.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }


        public double TimeSearchLastElementCollection3Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = collection3.ContainsValue(last);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchLastElementCollection4()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsLast = collection4.ContainsKey(last.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchLastElementCollection4Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool containsLast = collection4.ContainsValue(last);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchElementNotInCollection1()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = !collection1.Contains(noexist.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
        public double TimeSearchElementNotInCollection2()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = !collection2.Contains(noexist.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
        public double TimeSearchElementNotInCollection3()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = !collection3.ContainsKey(noexist.BasePlant);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchElementNotInCollection3Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = !collection3.ContainsValue(noexist);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchElementNotInCollection4()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = !collection4.ContainsKey(noexist.BasePlant.ToString());
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }

        public double TimeSearchElementNotInCollection4Value()
        {
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 1000;

            stopwatch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                bool contains = !collection4.ContainsValue(noexist);
            }
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
    }
}
